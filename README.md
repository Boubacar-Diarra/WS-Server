# WS-Server
Le processus décrit ici, la été de manière beaucoup plus détaillé dans la la doc officille : https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-3.1

1. git clone https://github.com/Boubacar-Diarra/WS-Server
2.  cd WS-Server
3. dotnet publish --configuration Release
4.Ci cette étape réussie, deux chemin seront affichés, choisir le premier et faire:
	dotnet chemin1
	Cette commande va ainsi lancé le projet
5. Installer Nginx (proxy reverser): sudo apt-get nginx
6. Lancer Nginx, cette commande est à exécuter une seule fois : sudo service nginx start
7. Paramétrer nginx
le fichier se trouve à l’adresse /etc/nginx/sites-available/default
Voici la config :
server {
        listen 80 default_server;
        listen [::]:80 default_server;
	  server_name localhost;

        location / {
                proxy_pass         http://localhost:5000;
                proxy_http_version 1.1;
                proxy_set_header   Upgrade $http_upgrade;
                proxy_set_header   Connection keep-alive;
                proxy_set_header   Host $host;
                proxy_cache_bypass $http_upgrade;
                proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
                proxy_set_header   X-Forwarded-Proto $scheme;
                proxy_method POST;
                error_page  405     =200 $uri;
                # First attempt to serve request as file, then
                # as directory, then fall back to displaying a 404.
                #try_files $uri $uri/ =404;
        }
}

Le port 80 devra être ouvert
