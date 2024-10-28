@echo off
title Restauration de la base de données - Restore Script

:: Message d'introduction
echo.
echo [92m===========================================
echo     RESTAURATION DE LA BASE DE DONNEES     
echo                 DEFAULT DB        
echo ============================================
echo.

:: Exécution de la commande de restauration
echo [93mRestauration en cours...
docker exec -i db mysql -u root -proot < ESR-A_ImportDump.sql

:: Vérification de succès ou d'erreur
if %errorlevel% equ 0 (
    echo.
    echo [92mRestauration terminée avec succès !
    echo La base de données a été restaurée depuis le fichier de sauvegarde.
) else (
    echo.
    echo [91mERREUR : La restauration a échoué.
)

:: Pause pour garder la fenêtre ouverte
echo.
pause
