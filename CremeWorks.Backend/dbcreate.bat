@echo off

docker pull mariadb
docker create --name db-webserver -e MYSQL_ROOT_PASSWORD=dLfU8nN45sP -e MYSQL_DATABASE=webserver -e MYSQL_USER=dbuser -e MYSQL_PASSWORD=yY6.!26X7PNC -p 3310:3306 mariadb
pause