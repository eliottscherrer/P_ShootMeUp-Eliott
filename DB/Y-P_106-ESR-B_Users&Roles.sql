-----------------------------------------------------------------------------------------------
------------------------------------------ [ ROLES ] ------------------------------------------
-----------------------------------------------------------------------------------------------
USE db_space_invaders;

-- Administrateurs --
CREATE ROLE 'Administrateurs';
-- Peut créer, lire, mettre à jour et supprimer (CRUD) n'importe quelle table.
-- Gérer les utilisateurs et leurs privilèges
GRANT CREATE, SELECT, UPDATE, DELETE ON * TO 'Administrateurs'@'localhost' WITH GRANT OPTION;

-- Joueurs --

CREATE ROLE 'Joueurs';
-- Lire les informations des armes (pour voir quelles armes il peut acheter).
GRANT SELECT ON t_arme TO 'Joueurs'@'localhost';
-- Créer une commande.
-- Lire toutes les commandes.
GRANT CREATE, SELECT ON t_commande TO 'Joueurs'@'localhost';

-- Gestionnaires de la boutique --

CREATE ROLE 'GestionnairesBoutique';
-- Lire les informations sur tous les joueurs (pour savoir qui a passé une commande).
GRANT SELECT ON t_joueur TO 'GestionnairesBoutique'@'localhost';
-- Mettre à jour, lire et supprimer des armes (ajout de nouvelles armes, modification des prix, etc.).
GRANT UPDATE, SELECT, DELETE ON t_arme TO 'GestionnairesBoutique'@'localhost';
-- Lire toutes les commandes.
GRANT SELECT ON t_commande TO 'GestionnairesBoutique'@'localhost';

-----------------------------------------------------------------------------------------------
------------------------------------------ [ USERS ] ------------------------------------------
-----------------------------------------------------------------------------------------------

-- Administrateur --
CREATE USER 'Administrateur'@'localhost' IDENTIFIED BY 'adminpass';
GRANT 'Administrateurs'@'localhost' TO 'Administrateur'@'localhost';
SET DEFAULT ROLE 'Administrateurs' FOR 'Administrateur'@'localhost';

-- Joueur --
CREATE USER 'Joueur1'@'localhost' IDENTIFIED BY 'joueur1pass';
GRANT 'Joueurs'@'localhost' TO 'Joueur1'@'localhost';
SET DEFAULT ROLE 'Joueurs' FOR 'Joueur1'@'localhost';

-- Gestionnaire de la boutique --
CREATE USER 'GestionnaireBoutique'@'localhost' IDENTIFIED BY 'gestionnairepass';
GRANT 'GestionnairesBoutique'@'localhost' TO 'GestionnaireBoutique'@'localhost';
SET DEFAULT ROLE 'GestionnairesBoutique' FOR 'GestionnaireBoutique'@'localhost';

FLUSH PRIVILEGES;

-----------------------------------------------------------------------------------------------
------------------------------------------ [ VERIF ] ------------------------------------------
-----------------------------------------------------------------------------------------------

-- Montrer les privilèges de chaque utilisateurs
SHOW GRANTS FOR 'Administrateur'@'localhost';
SHOW GRANTS FOR 'Joueur1'@'localhost';
SHOW GRANTS FOR 'GestionnaireBoutique'@'localhost';

---------------

USE db_space_invaders;

CREATE ROLE 'Administrateurs';

GRANT CREATE, SELECT, UPDATE, DELETE ON * TO 'Administrateurs'@'localhost' WITH GRANT OPTION;

CREATE ROLE 'Joueurs';
GRANT SELECT ON t_arme TO 'Joueurs'@'localhost';

GRANT CREATE, SELECT ON t_commande TO 'Joueurs'@'localhost';


CREATE ROLE 'GestionnairesBoutique';
GRANT SELECT ON t_joueur TO 'GestionnairesBoutique'@'localhost';
GRANT UPDATE, SELECT, DELETE ON t_arme TO 'GestionnairesBoutique'@'localhost';

GRANT SELECT ON t_commande TO 'GestionnairesBoutique'@'localhost';

CREATE USER 'Administrateur'@'localhost' IDENTIFIED BY 'adminpass';
GRANT 'Administrateurs'@'localhost' TO 'Administrateur'@'localhost';
SET DEFAULT ROLE 'Administrateurs' FOR 'Administrateur'@'localhost';

CREATE USER 'Joueur1'@'localhost' IDENTIFIED BY 'joueur1pass';
GRANT 'Joueurs'@'localhost' TO 'Joueur1'@'localhost';
SET DEFAULT ROLE 'Joueurs' FOR 'Joueur1'@'localhost';

CREATE USER 'GestionnaireBoutique'@'localhost' IDENTIFIED BY 'gestionnairepass';
GRANT 'GestionnairesBoutique'@'localhost' TO 'GestionnaireBoutique'@'localhost';
SET DEFAULT ROLE 'GestionnairesBoutique' FOR 'GestionnaireBoutique'@'localhost';

FLUSH PRIVILEGES;
SHOW GRANTS FOR 'Administrateur'@'localhost';
SHOW GRANTS FOR 'Joueur1'@'localhost';
SHOW GRANTS FOR 'GestionnaireBoutique'@'localhost';