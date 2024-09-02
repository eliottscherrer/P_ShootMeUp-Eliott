-- Requete 1
-- Sélectionner les 5 joueurs qui ont le meilleur score c’est-à-dire qui ont le nombre de points
-- le plus élevé. Les joueurs doivent être classés dans l’ordre décroissant
SELECT
    *
FROM
    t_joueur
ORDER BY
    jouNombrePoints
    DESC
LIMIT
    5;

-- Requete 2
-- Trouver le prix maximum, minimum et moyen des armes.
-- Les colonnes doivent avoir pour nom « PrixMaximum », « PrixMinimum » et « PrixMoyen)
SELECT
    MAX(armPrix) AS 'PrixMaximum',
    MIN(armPrix) AS 'PrixMinimum',
    AVG(armPrix) AS 'PrixMoyen'
FROM
    t_arme;

-- Requete 3
-- Trouver le nombre total de commandes par joueur et trier du plus grand nombre au plus petit.
-- La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom "NombreCommandes"
SELECT 
    fkJoueur AS 'IdJoueur',
    COUNT(fkJoueur) AS 'NombreCommandes'
FROM 
    t_commande
GROUP BY 
    fkJoueur
ORDER BY 
    NombreCommandes DESC;

-- Requete 4
-- Trouver les joueurs qui ont passé plus de 2 commandes.
-- La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom "NombreCommandes"
SELECT 
    fkJoueur AS 'IdJoueur',
    COUNT(fkJoueur) AS 'NombreCommandes'
FROM 
    t_commande
GROUP BY 
    fkJoueur
HAVING
    NombreCommandes > 2
ORDER BY 
    NombreCommandes DESC;

-- Requete 5
-- Trouver le pseudo du joueur et le nom de l'arme pour chaque commande.
SELECT 
    j.jouPseudo,
    a.armNom
FROM 
    t_commande c
    INNER JOIN t_joueur j ON c.fkJoueur = j.idJoueur
    INNER JOIN t_detail_commande dc ON c.idCommande = dc.fkCommande
    INNER JOIN t_arme a ON dc.fkArme = a.idArme;

-- ou

SELECT
    jouPseudo, arm.armNom
FROM
    t_joueur jo,
    t_commande co
    t_detail_commande dc,
    t_arme arm
WHERE
    idJoueur = co.fkJoueur AND
    dc.fkCommande = co.idCommande AND
    dc.fkArme = arm.idArme;

-- Requete 6
-- Trouver le total dépensé par chaque joueur en ordonnant par le montant le plus élevé en 
-- premier, et limiter aux 10 premiers joueurs.
-- La 1ère colonne doit avoir pour nom "IdJoueur" et la 2ème colonne "TotalDepense"
SELECT 
    c.fkJoueur AS 'IdJoueur',
    SUM(a.armPrix * dc.detQuantiteCommande) AS 'TotalDepense'
FROM 
    t_commande c
    INNER JOIN t_detail_commande dc ON c.idCommande = dc.fkCommande
    INNER JOIN t_arme a ON dc.fkArme = a.idArme
GROUP BY 
    c.fkJoueur
ORDER BY 
    TotalDepense DESC
LIMIT 10;

-- Requete 7
-- Récupérez tous les joueurs et leurs commandes, même s'ils n'ont pas passé de commande.
-- Dans cet exemple, même si un joueur n'a jamais passé de commande, il sera quand 
-- même listé, avec des valeurs `NULL` pour les champs de la table `t_commande`.
SELECT 
    j.*,
    c.*
FROM 
    t_joueur j
    LEFT JOIN t_commande c ON j.idJoueur = c.fkJoueur
    LEFT JOIN t_detail_commande dc ON c.idCommande = dc.fkCommande
    LEFT JOIN t_arme a ON dc.fkArme = a.idArme;

-- ou 

SELECT
    jou.*, co.*
FROM
    t_joueur jou
    LEFT JOIN t_commande co ON jou.idJoueur = co.fkJoueur
    LEFT JOIN t_detail_commande dc ON co.idCommande = dc.fkCommande;

-- Requete 8
-- Récupérer toutes les commandes et afficher le pseudo du joueur s’il existe, sinon afficher
-- `NULL` pour le pseudo. 
SELECT 
    c.*,
    j.jouPseudo
FROM 
    t_commande c
    LEFT JOIN t_joueur j ON c.fkJoueur = j.idJoueur;

-- Requete 9
-- Trouver le nombre total d'armes achetées par chaque joueur (même si ce joueur n'a 
-- acheté aucune Arme)


-- Requete 10
-- Trouver les joueurs qui ont acheté plus de 3 types d'armes différentes.
