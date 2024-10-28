@echo off
title Sauvegarde de la base de données - Backup Script

:: Couleurs de texte et d'arrière-plan
color 1F

:: Message d'introduction
echo ===========================================
echo       SAUVEGARDE DE LA BASE DE DONNEES     
echo ===========================================
echo.

:: Exécution de la commande de sauvegarde
echo Sauvegarde en cours...
docker exec -i db mysqldump -u root -proot --databases db_space_invaders > db_space_invaders_backup.sql

:: Vérification de succès ou d'erreur
if %errorlevel% equ 0 (
    echo.
    echo Sauvegarde terminée avec succès !
    echo Le fichier de sauvegarde se trouve dans le répertoire actuel.
) else (
    echo.
    echo ERREUR : La sauvegarde a échoué.
)

:: Pause pour garder la fenêtre ouverte
echo.
pause
