-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 1 ] ------------------------------
-- ------------------------------------------------------------------------
-- Sélectionner les 5 joueurs qui ont le meilleur score c’est-à-dire qui ont le nombre de points
-- le plus élevé. Les joueurs doivent être classés dans l’ordre décroissant
SELECT
    * -- Sélectionne toutes les colonnes de la table.
FROM
    t_joueur -- Spécifie la table source "t_joueur" pour récupérer les données des joueurs.
ORDER BY
    jouNombrePoints -- Trie les joueurs par "jouNombrePoints" (nombre de points) en ordre décroissant.
    DESC -- Indique un tri décroissant pour afficher les plus hauts scores en premier.
LIMIT
    5; -- Limite la sélection aux 5 premiers résultats.

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 2 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver le prix maximum, minimum et moyen des armes.
-- Les colonnes doivent avoir pour nom « PrixMaximum », « PrixMinimum » et « PrixMoyen)
SELECT
    MAX(armPrix) AS PrixMaximum, -- Récupère le prix maximum de "armPrix" avec l'alias "PrixMaximum".
    MIN(armPrix) AS PrixMinimum, -- Récupère le prix minimum de "armPrix" avec l'alias "PrixMinimum".
    AVG(armPrix) AS PrixMoyen -- Calcule le prix moyen de "armPrix" avec l'alias "PrixMoyen".
FROM
    t_arme;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 3 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver le nombre total de commandes par joueur et trier du plus grand nombre au plus petit.
-- La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom "NombreCommandes"
SELECT 
    fkJoueur AS IdJoueur, -- "fkJoueur" avec alias pour identifier chaque joueur.
    COUNT(fkJoueur) AS NombreCommandes -- Compte le nombre total de commandes par joueur.
FROM 
    t_commande
GROUP BY 
    fkJoueur -- Groupe par joueur.
ORDER BY 
    NombreCommandes DESC; -- Trie pour les joueurs ayant le plus de commandes.

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 4 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver les joueurs qui ont passé plus de 2 commandes.
-- La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom "NombreCommandes"
SELECT 
    fkJoueur AS IdJoueur,
    COUNT(fkJoueur) AS NombreCommandes -- Compte les commandes par joueur.
FROM 
    t_commande
GROUP BY 
    fkJoueur
HAVING
    NombreCommandes > 2 -- Inclut les joueurs avec plus de 2 commandes.
ORDER BY 
    NombreCommandes DESC;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 5 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver le pseudo du joueur et le nom de l'arme pour chaque commande.
SELECT 
    j.jouPseudo, -- Affiche le pseudo du joueur.
    a.armNom -- Affiche le nom de l'arme.
FROM 
    t_commande c
    INNER JOIN t_joueur j ON c.fkJoueur = j.idJoueur -- Joint les joueurs aux commandes.
    INNER JOIN t_detail_commande dc ON c.idCommande = dc.fkCommande -- Joint les détails de commande.
    INNER JOIN t_arme a ON dc.fkArme = a.idArme; -- Joint les armes pour obtenir leur nom.

-- ou

SELECT
    jouPseudo, arm.armNom
FROM
    t_joueur jo,
    t_commande co,
    t_detail_commande dc,
    t_arme arm
WHERE
    idJoueur = co.fkJoueur AND
    dc.fkCommande = co.idCommande AND
    dc.fkArme = arm.idArme;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 6 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver le total dépensé par chaque joueur en ordonnant par le montant le plus élevé en 
-- premier, et limiter aux 10 premiers joueurs.
-- La 1ère colonne doit avoir pour nom "IdJoueur" et la 2ème colonne "TotalDepense"
SELECT 
    c.fkJoueur AS IdJoueur,
    SUM(a.armPrix * dc.detQuantiteCommande) AS TotalDepense -- Calcule le total dépensé par joueur.
FROM 
    t_commande c
    INNER JOIN t_detail_commande dc ON c.idCommande = dc.fkCommande
    INNER JOIN t_arme a ON dc.fkArme = a.idArme
GROUP BY 
    c.fkJoueur
ORDER BY 
    TotalDepense DESC
LIMIT 10;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 7 ] ------------------------------
-- ------------------------------------------------------------------------
-- Récupérez tous les joueurs et leurs commandes, même s'ils n'ont pas passé de commande.
-- Dans cet exemple, même si un joueur n'a jamais passé de commande, il sera quand 
-- même listé, avec des valeurs `NULL` pour les champs de la table `t_commande`.
SELECT 
    j.*, -- Sélectionne toutes les colonnes de la table "t_joueur" raccourcie t
    c.* -- Sélectionne toutes les colonnes de la table "t_commande" raccourcie c
FROM 
    t_joueur j
    LEFT JOIN t_commande c ON j.idJoueur = c.fkJoueur
    LEFT JOIN t_detail_commande dc ON c.idCommande = dc.fkCommande
    LEFT JOIN t_arme a ON dc.fkArme = a.idArme;

-- ou 

SELECT
    j.*, co.*
FROM
    t_joueur j
    LEFT JOIN t_commande co ON j.idJoueur = co.fkJoueur
    LEFT JOIN t_detail_commande dc ON co.idCommande = dc.fkCommande;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 8 ] ------------------------------
-- ------------------------------------------------------------------------
-- Récupérer toutes les commandes et afficher le pseudo du joueur s’il existe, sinon afficher
-- `NULL` pour le pseudo. 
SELECT 
    c.*,
    j.jouPseudo
FROM 
    t_commande c
    LEFT JOIN t_joueur j ON c.fkJoueur = j.idJoueur;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 9 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver le nombre total d'armes achetées par chaque joueur (même si ce joueur n'a acheté aucune Arme)
SELECT 
    j.idJoueur, 
    j.jouPseudo, 
    IFNULL(SUM(dc.detQuantiteCommande), 0) AS totalArmesAchetees -- Somme des quantités d'armes achetées, en affichant 0 pour les joueurs sans achats.
FROM 
    t_joueur j
LEFT JOIN 
    t_commande c ON j.idJoueur = c.fkJoueur
LEFT JOIN 
    t_detail_commande dc ON c.idCommande = dc.fkCommande
GROUP BY 
    j.idJoueur, j.jouPseudo;

-- ------------------------------------------------------------------------
-- --------------------------- [ Requete 10 ] ------------------------------
-- ------------------------------------------------------------------------
-- Trouver les joueurs qui ont acheté plus de 3 types d'armes différentes.
SELECT 
    j.*,
    COUNT(DISTINCT dc.fkArme) AS NombreArmesDifferentesAchetees -- Compte le nombre distinct d'armes achetées.
FROM 
    t_joueur j
INNER JOIN 
    t_commande c ON j.idJoueur = c.fkJoueur
INNER JOIN 
    t_detail_commande dc ON c.idCommande = dc.fkCommande
GROUP BY 
    j.idJoueur, j.jouPseudo
HAVING 
    COUNT(DISTINCT dc.fkArme) > 3;