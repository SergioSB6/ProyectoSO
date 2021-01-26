#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

//Declaracion de estructuras
typedef struct{
	char nombre[20];
	int socket;
}Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
}ListaConectados;

typedef struct{
ListaConectados salas[100];
int num;
}ListaSalas;

//Declaracion de variables globales
int contador_servicios=0;
int i;
int sockets[100];
char dir1 [20], dir2 [20];

ListaSalas listaSalas;
ListaConectados jugadoresConectados;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

//Funciones


int Pon (ListaConectados *lista, char nombre[20], int socket){
	//Anade conectados a la lista
	if(lista ->num ==100) return -1;
	
	strcpy(lista->conectados[lista->num].nombre, nombre);
	lista->conectados[lista->num].socket = socket;
	lista->num ++;
	printf ("Conectado: %s\n", lista->conectados[lista->num -1].nombre);
	return 3;
}
int DameSocket (ListaConectados *lista, char nombre[20]){
	//Devuelve el socket del nombre introducido que esta en la lista
	int i=0;
	int encontrado=0;
	while ((i<lista->num)&&!encontrado){
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		else
			i=i+1;
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else
		return -1;
}
int DamePosicion (ListaConectados *lista, char nombre[20]){
	//Devuelve la posicion del nombre introducido que esta en la lista
	int i=0;
	int encontrado=0;
	while ((i<lista->num)&&!encontrado){
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		else
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}

int Elimina (ListaConectados *lista, char nombre[20]){
	//Elimina en nombre de la lista de conectados
	int pos = DamePosicion (lista, nombre);
	if (pos==-1)
		return -1;
	else {
		int i;
		for (i=pos; i<lista->num-1; i++)
		{
			lista-> conectados [i] = lista->conectados[i+1];
			//strcpy(lista->conectados[i].nombre = lista->conectados[i+1].nombre, nombre);
			//lista->conectados[i].socket =lista->conectados[i+1].socket;
		}
		lista ->num--;
		return 0;
	}
}

void DameConectados (ListaConectados *lista, char conectados[300]){
	//Pone en un vector los nombres de conectados separados por una bcoma
	//Primero pone el n�mero de conectados. Ej: 3,Maria,Juan,Pedro
	sprintf (conectados, "%d", lista->num);
	printf ("%d",lista->num);
	int i;
	for (i=0; i<lista->num; i++)
		sprintf (conectados, "%s,%s", conectados, lista->conectados[i].nombre);
}

void DameTodosSockets (ListaConectados *lista, char conectados[300], char sockets[300]){
	//Pone en un vector los sockets de conectados separados por una coma. Ej: 2,3,4
	int i;
	int o =0;
	char socket[10];
	char nombre[20];
	char *p = strtok (conectados, ",");
	int n = atoi (p);
	p = strtok (NULL, ",");
	strcpy (nombre, p);
	
	for (;;)
		if (strcmp (lista->conectados[i].nombre, nombre)==0){
			sprintf(socket, "%d", lista->conectados[i].socket);
			strcat (sockets, socket); 
			if (o< n-1){
				strcat (sockets, ",");
				p = strtok (NULL, ",");
				strcpy (nombre, p);
			}
			o++;
	}
}
int ComprobarSala (ListaSalas *listaSalas, char nombre [20])
{
	printf("Lista salas num: %d \n", listaSalas->num);
	for (int i =0; i< listaSalas->num; i++)
	{
		for (int a =0; a< listaSalas->salas[i].num; a++)
		{
			if(strcmp(listaSalas->salas[i].conectados[a].nombre, nombre))
			{
				return i;
			}
		}
	}
	return -1;
}

int CrearSala (ListaSalas *listaSalas, char nombre[20], int socket){
	//Anade conectados a la lista
	if(listaSalas->num ==100)
		return -1;
	else{
		Pon(&listaSalas->salas[listaSalas->num], nombre, socket);
		listaSalas->num ++;
		return 1;
	}
}

void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s = (int * ) socket;
	sock_conn = *s;
	int ret;
	MYSQL *conn;
	int err;
	
	//Establecer conexion con la base de datos
	conn = mysql_init(NULL);
	if (conn==NULL) 
	{
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//Inicializa la conexion
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M2JUEGO",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	char peticion[512];
	char respuesta[512];
	int terminar =0;
	
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		char respuesta[512];
		MYSQL_RES *resultado;
		MYSQL_ROW row;
		// Ahora recibimos la peticion
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que anadirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		printf ("P: %s\n",peticion);
		
		//Atendemos la peticion
		char *t = strtok (peticion, "/");
		int codigo =  atoi (t);
		printf ("Codigo: %d \n", codigo);
		
		char nombre[20];
		
		if (codigo ==0) //peticion de desconexion
		{
			t = strtok( NULL, "/");
			char nombre_usuario[40];
			
			if (t!= NULL)
			{
				strcpy (nombre_usuario, t);
				pthread_mutex_lock(&mutex); //No interrumpir
				int eliminar = Elimina (&jugadoresConectados, nombre_usuario);
				pthread_mutex_unlock(&mutex); //Ahora si se puede interrumpir
				if (eliminar==0)
					printf("Usuario eliminado de la lista de conectados. \n");
				else
					printf("Error al eliminar el usuario de la lista de conectados. \n");
			}
			terminar=1;
		}
		
		else if (codigo ==100)
		{
			//ID/Contrase�a
			char nombre_usuario[40];
			char contrasena [40];
			char consulta [800];
			
			t = strtok( NULL, "/");
			strcpy (nombre_usuario, t);
			printf("Nombre usuario %s\n", nombre_usuario);
			
			strcpy (consulta,"SELECT JUGADORES.Contrasena FROM JUGADORES WHERE JUGADORES.Usuario = '"); 
			strcat (consulta, nombre_usuario);
			strcat (consulta,"'");
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos2 de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
			{
				printf ("No se han obtenido usuario en la consulta\n");
				sprintf (respuesta,"100/NoUser");
			}
			
			else
			{
				t = strtok( NULL, "/");
				strcpy (contrasena, t);
				printf("Con recib %s\n", contrasena);
				printf("con db %s\n",row[0]);
				
				if (strcmp(contrasena,row[0]) == 0)
				{
					sprintf (respuesta,"100/Correct");
					pthread_mutex_lock(&mutex); //No interrumpir
					int poner = Pon (&jugadoresConectados, nombre_usuario, jugadoresConectados.num);
					pthread_mutex_unlock(&mutex); //Ahora si se puede interrumpir
					if (poner == 3)
					{
						printf("Usuario anadido a la lista de conectados. \n");
						
					}
					else
						printf("Error al introducir al usuario a la lista de conectados. \n");
				}
				
				else 
				{
					sprintf (respuesta,"100/Incorrect");
				}	
			}	
			printf ("%s",respuesta);
		}
		
		else if (codigo ==101)
		{
			//ID/Contrase�a
			char nombre_usuario[40];
			char contrasena [40];
			char consulta [800];
			
			t = strtok( NULL, "/");
			strcpy (nombre_usuario, t);
			printf("Nombre usuario %s\n", nombre_usuario);
			
			t = strtok( NULL, "/");
			strcpy (contrasena, t);
			printf("Contrasena %s\n", contrasena);
			
			strcpy (consulta,"SELECT JUGADORES.ID FROM JUGADORES WHERE JUGADORES.Usuario ='"); 
			strcat (consulta,nombre_usuario);
			strcat (consulta,"';");
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos2 de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}

			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
			{
				
				strcpy (consulta,"SELECT COUNT(ID) FROM JUGADORES;"); 
	
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos2 de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				int max_ID;
				char ID[80];
				
				resultado = mysql_store_result (conn); 
				row = mysql_fetch_row (resultado);

				max_ID = atoi(row[0]) + 1;

				strcpy (consulta, "INSERT INTO JUGADORES VALUES (");
				//convertimos el ID en un string y lo concatenamos 
				
				sprintf(ID, "%d", max_ID);
				printf("ID: %s\n",ID);
				strcat (consulta, ID); 
				strcat (consulta, ",'");
				//concatenamos el nombre
				strcat (consulta, nombre_usuario); 
				strcat (consulta, "','");
				//concatenamos la contrasena
				strcat (consulta, contrasena); 
				strcat (consulta, "');");
				
				err = mysql_query(conn, consulta);
				if (err!=0) {
					printf ("Error al introducir datos la base %u %s\n", 
							mysql_errno(conn), mysql_error(conn));
					sprintf (respuesta, "101/Incorrect2");
				}
				
				else
				{
					sprintf (respuesta,"101/Correct");
				}	
				printf ("%s",respuesta);
			}
			else
				sprintf (respuesta, "101/Incorrect");
		}
		
		else if (codigo ==1) //Consultar el numero de partidas que ha ganado un jugador
		{	
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			char consulta [800];
			//nombre
			char nombre[40];

			t = strtok( NULL, "/");
			strcpy (nombre, t);
			printf("Nombre usuario %s\n", nombre);

			strcpy (consulta,"SELECT COUNT(PARTIDAS.ID) FROM (PARTIDAS, JUGADORES, PARTICIPACION) WHERE PARTIDAS.ganador= '"); 
			strcat (consulta, nombre);
			strcat (consulta,"' AND JUGADORES.ID=PARTICIPACION.ID_J AND PARTIDAS.ID=PARTICIPACION.ID_P     AND    PARTICIPACION.ID_J = (SELECT JUGADORES.ID FROM JUGADORES WHERE JUGADORES.Usuario = '");
			strcat (consulta, nombre);
			strcat (consulta, "');");

			err=mysql_query (conn, consulta);
			
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//Recogemos el resultado de la consulta
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
	
			if (row == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
			}

			else 
			{
				printf ("El jugador %s ha ganado %s s\n", nombre, row[0]);
			}
			
			sprintf (respuesta,"1/%s",row[0]);
		}
		
		else if (codigo == 2)//Consultar jugadores que han ganado una partida de mas de 10 minutos
		{
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			char consulta [800];

			strcpy (consulta,"SELECT DISTINCT PARTIDAS.Ganador FROM (PARTIDAS, JUGADORES, PARTICIPACION)  WHERE  PARTIDAS.Duracion > 10   AND    JUGADORES.ID = PARTICIPACION.ID_J   AND    PARTIDAS.ID = PARTICIPACION.ID_P;"); 

			err=mysql_query (conn, consulta);
			
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//Recogemos el resultado de la consulta
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			char vector_nombres[500];
			
			if (row == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
			}

			else 
			{
				strcpy(vector_nombres,row[0]);
				row = mysql_fetch_row (resultado);
				while (row !=NULL) 
				{
					strcat(vector_nombres," ");
					strcat(vector_nombres,row[0]);
					row = mysql_fetch_row (resultado);
				}
				sprintf (respuesta,"2/%s", vector_nombres);
			}
			
		}
		
		else if (codigo == 3) //Consultar fecha y horade una patida
		{
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			char consulta [800];
			char IDpartida [10];
			
			t = strtok( NULL, "/");
			strcpy (IDpartida, t);
			strcpy (consulta,"SELECT PARTIDAS.Fecha_Hora FROM (PARTIDAS, JUGADORES, PARTICIPACION) WHERE  PARTIDAS.ID = ");
			strcat (consulta,IDpartida);
			strcat (consulta," AND    JUGADORES.ID = PARTICIPACION.ID_J		AND    PARTIDAS.ID = PARTICIPACION.ID_P;"); 

			err=mysql_query (conn, consulta);
			
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//Recogemos el resultado de la consulta
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);

			if (row == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
			}

			else 
			{
				if (row[0] == 0)
					strcpy(respuesta,"3/NoExist");
				else
					sprintf (respuesta,"3/%s", row[0]);
			}

		}
		
		
		
		else if (codigo == 4)
		{
			
			
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			char consulta [800];
			char dia [20];
			char usuario [20];
			
			t = strtok( NULL, "-");
			strcpy (usuario, t);
			
			t = strtok( NULL, "-");
			strcpy (dia, t);
			strcpy (consulta,"SELECT COUNT(PARTICIPACION.ID_J) FROM (PARTIDAS, JUGADORES, PARTICIPACION) WHERE  SUBSTRING(PARTIDAS.Fecha_Hora, 1, 10)  = '");
			strcat (consulta,dia);
			strcat (consulta,"' AND PARTICIPACION.ID_J = (SELECT ID FROM JUGADORES WHERE Usuario = '");
			strcat (consulta,usuario);
			strcat (consulta, "')	AND    JUGADORES.ID = PARTICIPACION.ID_J	AND    PARTIDAS.ID = PARTICIPACION.ID_P;");

			err=mysql_query (conn, consulta);
			
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//Recogemos el resultado de la consulta
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);

			if (row == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
			}

			else 
			{
				char resp[20];
				sprintf(resp,"4/%d",atoi(row[0]));
				strcpy(respuesta, resp);
			}	
			
		}
		
		else if(codigo == 5)
		{		
			char usuario [20];			
			t = strtok( NULL, "/");
			strcpy (usuario, t);
			
			int i = 0;
			char usuarioActual [20];
			for(i;i< jugadoresConectados.num; i++)
			{
				if(sock_conn == sockets[jugadoresConectados.conectados[i].socket])
				{
					strcpy(usuarioActual, jugadoresConectados.conectados[i].nombre);
					break;
				}
			}
			
			
			
			//Envio la comfirmacion al jugador que ha enviado la invitacion
			printf("He enviado una invitacion a %s \n", usuario);
			char resp[20];
			sprintf(resp,"8/");
			strcpy(respuesta, resp);
			
			//Envio invitacion al socket del invitado
			char resp1[20];
			sprintf(resp1,"9/%s",usuarioActual);
			int socketInvitado = DameSocket(&jugadoresConectados, usuario);
			write (sockets[socketInvitado], resp1, strlen(resp1));
		}
		
		else if(codigo == 6)
		{				
			char usuario [20];			
			t = strtok( NULL, "-");
			strcpy (usuario, t);
			
			char result [20];			
			t = strtok( NULL, "-");
			strcpy (result, t);
			
			
			
			/*t = strtok( NULL, "/");
			strcpy (usuario, t);		
			t = strtok(NULL, "-");
			strcpy (result, t);*/

			char usuarioActual [20];
			int i = 0;
			for(i;i< jugadoresConectados.num; i++)
			{
				if(sock_conn == sockets[jugadoresConectados.conectados[i].socket])
				{
					strcpy(usuarioActual, jugadoresConectados.conectados[i].nombre);
					break;
				}
			}
								
			printf("el resultado de la invitacion es %s \n",usuarioActual);	
			
			char resp[20];
			sprintf(resp,"10/%s,%s,", usuarioActual, result);
			int socketInvitado = DameSocket(&jugadoresConectados, usuario);
			write (sockets[socketInvitado], resp, strlen(resp));
			
			//Si el resultado es si, creamos la sala con dos jugadores
			if (strcmp(result,"yes") == 0)
			{				
				int indiceSala = ComprobarSala(&listaSalas, usuario);
				for(i = 0;i< jugadoresConectados.num; i++)
				{
					if(strcmp(usuario, jugadoresConectados.conectados[i].nombre) == 0)
					{
						write(sockets[jugadoresConectados.conectados[i].socket], "13/", strlen("13/"));
						break;
					}
				}
				
				if(indiceSala != -1)
				{
					Pon(&listaSalas.salas[indiceSala], usuarioActual, sock_conn);	
				}
				else
				{
								
					//crear sala
					CrearSala(&listaSalas, usuario, sockets[socketInvitado]);
					Pon(&listaSalas.salas[listaSalas.num - 1], usuarioActual, sock_conn);
				}
					
			}
			
		}
	
		 else if(codigo==8)
		{
			
			char usuario [20];			
			t = strtok( NULL, "-");
			strcpy (usuario, t);
			
			char mensaje [20];			
			t = strtok( NULL, "-");
			strcpy (mensaje, t);
			
			char usuarioActual [20];
			int i = 0;
			for(i;i< jugadoresConectados.num; i++)
			{
				if(sock_conn == sockets[jugadoresConectados.conectados[i].socket])
				{
					strcpy(usuarioActual, jugadoresConectados.conectados[i].nombre);
					break;
				}
			}
			
			char resp[20];
			sprintf(resp,"11/%s,%s",usuario, mensaje);
			strcpy(respuesta, resp);
			
			int indice = ComprobarSala(&listaSalas, usuarioActual);
			printf("indice: %d\n", indice);
			printf("Numero de gente en la sala: %d\n", listaSalas.salas[indice].num);
			
			for (int a =0; a< listaSalas.salas[indice].num; a++)
			{
				write(listaSalas.salas[indice].conectados[a].socket, respuesta, strlen(respuesta));
			}
		}
		 
		 else if(codigo == 9)
		 {
			 char usuarioActual [20];
			 int i = 0;
			 for(i;i< jugadoresConectados.num; i++)
			 {
				 if(sock_conn == sockets[jugadoresConectados.conectados[i].socket])
				 {
					 strcpy(usuarioActual, jugadoresConectados.conectados[i].nombre);
					 break;
				 }
			 }
			 
			 int indiceSala = ComprobarSala(&listaSalas, usuarioActual);
			 
			 for(int k =0; k< listaSalas.salas[indiceSala].num; k++)
			 {
				char resp1[20];
				sprintf(resp1, "12/%d,%d", k, listaSalas.salas[indiceSala].num);
				printf("%d", k);
				write (listaSalas.salas[indiceSala].conectados[k].socket, resp1, strlen(resp1));
			 }
		 }
		 else if(codigo == 21) 
		 {
			char num [20];
			t = strtok( NULL, "/");
			strcpy (num, t);
			
			char dir [20];
			t = strtok( NULL, "/");
			strcpy (dir, t);
			
			char usuarioActual [20];
			int i = 0;
			for(i;i< jugadoresConectados.num; i++)
			{
				if(sock_conn == sockets[jugadoresConectados.conectados[i].socket])
				{
					strcpy(usuarioActual, jugadoresConectados.conectados[i].nombre);
					break;
				}
			}
			
			int indiceSala = ComprobarSala(&listaSalas, usuarioActual);
			
			for(int k =0; k< listaSalas.salas[indiceSala].num; k++)
			{
								
				printf("Envio 14");
				char resp1[20];
				sprintf(resp1, "14/%s,%s", num, dir);
				write (listaSalas.salas[indiceSala].conectados[k].socket, resp1, strlen(resp1));
			}
			
		 }
		 else if(codigo == 22) 
		 {
			 char resp1[20];
			 strcpy(resp1, dir1);
			 write(sockets[jugadoresConectados.conectados[1].socket], resp1, strlen(resp1));
		 }
		 else if(codigo == 23) 
		 {
			 char resp1[20];
			 strcpy(resp1, dir2);
			 write(sockets[jugadoresConectados.conectados[2].socket], resp1, strlen(resp1));
		 }
		 

		if (codigo != 0 && codigo != 6 && codigo != 8 )
		{
			// Enviamos respuesta
			printf("\nrespuesta: %s\n",respuesta);
			
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		if ((codigo ==1)||(codigo ==2)||(codigo ==3)||(codigo ==4))
		{
			
			pthread_mutex_lock(&mutex); //No interrumpir
			contador_servicios = contador_servicios +1;
			pthread_mutex_unlock(&mutex); //Ahora si se puede interrumpir
			//notificar
			for(int j = 0;j< jugadoresConectados.num; j++)
			{
				if(sock_conn == sockets[jugadoresConectados.conectados[j].socket])
				{				
				char notificacion[20];
				sprintf (notificacion,"6/%d",contador_servicios);
				write (sockets[jugadoresConectados.conectados[j].socket], notificacion, strlen(notificacion));
				}
			}
		}
		if (codigo ==100 || codigo==0)
		{
			char misConectados [300];
			char notificacion [310];
			DameConectados (&jugadoresConectados, misConectados);
			
			sprintf(notificacion, "7/%s",misConectados);
			int j;
			for (j=0; j<i; j++)				
				write (sockets[j], notificacion, strlen(notificacion));
		}
	}
	//Finalizamos el servicio al cliente
	close(sock_conn);
	mysql_close (conn);
}	

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;

	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// Establecemos el puerto 
	serv_adr.sin_port = htons(50009);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	pthread_t thread[100];
	i=0;
	
	//Inicializacion de variables globales
	contador_servicios = 0;
	jugadoresConectados.num = 0;
	
	// Bucle infinito
	for (;;){
		printf ("Escuchando...\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion.\n");
		//sock_conn es el socket que usaremos para este cliente
		sockets[i] = sock_conn;
		pthread_create (&thread[i], NULL, AtenderCliente, &sockets[i]);
		i++;
	}
}
