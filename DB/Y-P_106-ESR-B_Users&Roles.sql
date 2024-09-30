-- --------------------------------------------------------------------------------------------
-- ---------------------------------------- [ ROLES ] -----------------------------------------
-- --------------------------------------------------------------------------------------------
USE db_space_invaders;

-- Administrateurs --
CREATE ROLE 'Administrateurs';
-- Peut créer, lire, mettre à jour et supprimer (CRUD) n'importe quelle table.
-- Gérer les utilisateurs et leurs privilèges
GRANT CREATE, SELECT, UPDATE, DELETE ON * TO 'Administrateurs' WITH GRANT OPTION;

-- Joueurs --

CREATE ROLE 'Joueurs';
-- Lire les informations des armes (pour voir quelles armes il peut acheter).
GRANT SELECT ON t_arme TO 'Joueurs';
-- Créer une commande.
-- Lire toutes les commandes.
GRANT CREATE, SELECT ON t_commande TO 'Joueurs';

-- Gestionnaires de la boutique --

CREATE ROLE 'GestionnairesBoutique';
-- Lire les informations sur tous les joueurs (pour savoir qui a passé une commande).
GRANT SELECT ON t_joueur TO 'GestionnairesBoutique';
-- Mettre à jour, lire et supprimer des armes (ajout de nouvelles armes, modification des prix, etc.).
GRANT UPDATE, SELECT, DELETE ON t_arme TO 'GestionnairesBoutique';
-- Lire toutes les commandes.
GRANT SELECT ON t_commande TO 'GestionnairesBoutique';

-- --------------------------------------------------------------------------------------------
-- ---------------------------------------- [ USERS ] -----------------------------------------
-- --------------------------------------------------------------------------------------------

-- Administrateur --
CREATE USER 'Administrateur' IDENTIFIED BY 'adminpass';
GRANT 'Administrateurs' TO 'Administrateur';
SET DEFAULT ROLE 'Administrateurs' TO 'Administrateur';

-- Joueur --
CREATE USER 'Joueur1' IDENTIFIED BY 'joueur1pass';
GRANT 'Joueurs' TO 'Joueur1';
SET DEFAULT ROLE 'Joueurs' TO 'Joueur1';

-- Gestionnaire de la boutique --
CREATE USER 'GestionnaireBoutique' IDENTIFIED BY 'gestionnairepass';
GRANT 'GestionnairesBoutique' TO 'GestionnaireBoutique';
SET DEFAULT ROLE 'GestionnairesBoutique' TO 'GestionnaireBoutique';

FLUSH PRIVILEGES;

-- --------------------------------------------------------------------------------------------
-- ---------------------------------------- [ VERIF ] -----------------------------------------
-- --------------------------------------------------------------------------------------------

-- Montrer les privilèges de chaque utilisateurs
SHOW GRANTS FOR 'Administrateur';
SHOW GRANTS FOR 'Joueur1';
SHOW GRANTS FOR 'GestionnaireBoutique';