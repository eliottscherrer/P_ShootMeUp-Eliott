@echo off
title Sauvegarde de la base de données - Backup Script

:: Message d'introduction
echo.
echo [94m===========================================
echo       SAUVEGARDE DE LA BASE DE DONNEES     
echo ============================================
echo.

:: Exécution de la commande de sauvegarde
echo [93mSauvegarde en cours...
docker exec -i db mysqldump -u root -proot --databases db_space_invaders > ESR-A_ImportDump.sql

:: Vérification de succès ou d'erreur
if %errorlevel% equ 0 (
    echo.
    echo [92mSauvegarde terminée avec succès !
    echo Le fichier de sauvegarde se trouve dans le répertoire actuel.
) else (
    echo.
    echo [91mERREUR : La sauvegarde a échoué.
)

:: Pause pour garder la fenêtre ouverte
echo.
pause
