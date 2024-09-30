@echo off
REM "Sauvegarde (Backup)"
docker exec -it db mysqldump -u root -proot db_space_invaders > db_space_invaders_backup.sql

REM "Restore"
docker exec -i db mysql -u root -proot db_space_invaders < db_space_invaders_backup.sql

pause