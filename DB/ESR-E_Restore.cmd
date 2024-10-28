@echo off
title Restauration de la base de données - Restore Script

:: Couleurs de texte et d'arrière-plan
color 2F

:: Message d'introduction
echo ===========================================
echo     RESTAURATION DE LA BASE DE DONNEES     
echo ===========================================
echo.

:: Exécution de la commande de restauration
echo Restauration en cours...
docker exec -i db mysql -u root -proot < db_space_invaders_backup.sql

:: Vérification de succès ou d'erreur
if %errorlevel% equ 0 (
    echo.
    echo Restauration terminée avec succès !
    echo La base de données a été restaurée depuis le fichier de sauvegarde.
) else (
    echo.
    echo ERREUR : La restauration a échoué.
)

:: Pause pour garder la fenêtre ouverte
echo.
pause
