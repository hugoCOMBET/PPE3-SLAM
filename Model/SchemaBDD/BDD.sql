drop database if exists LSRGames ; 

create database LSRGames; 

use LSRGames; 

  

  

  

create table Utilisateur( 

id int, 

Login varchar(75) unique, 

MotDePasse varchar(30), 

primary key(id) 

) engine InnoDB; 

  

  

  

create table Client( 

id int, 

nom varchar(30), 

prenom varchar(30), 

photo varchar(200), 

adresse varchar(150), 

DateNaissance date, 

Email varchar(150), 

TelephonePortable char(10),  

Credit double, 

primary key(id) 

) engine InnoDB; 

  

  

  

create table Obstacle( 

nom varchar(100), 

UneDefinition varchar(255), 

Photo varchar(255), 

typeObstacle varchar(75), 

primary key(nom) 

)engine InnoDB; 

  

  

  

create table Themes( 

id int, 

theme varchar(50), 

primary key(id) 

)engine InnoDB; 

  

  

  

create table Salle( 

id int, 

ville varchar(45), 

idTheme int, 

primary key(id), 

foreign key (idTheme) references Themes(id) on update cascade on delete cascade 

)engine InnoDB; 

  

  

  

create table Transactions( 

id int, 

idClient int, 

MontantTransaction double, 

primary key(id), 

foreign key(idClient) references Client(id) on update cascade on delete cascade 

) engine InnoDB; 

  

  

  

create table Reservation( 

id int, 

idClient int, 

DateReservation DateTime, 

nbJoueurs int check(nbJoueurs <=7), 

nbObstacle int check(nbObstacle <=12), 

idSalle int, 

idTransaction int, 

primary key(id), 

foreign key(idClient) references Client(id) on update cascade on delete cascade, 

foreign key(idSalle) references Salle(id) on update cascade on delete cascade, 

foreign key(idTransaction) references Transactions(id) on update cascade on delete cascade 

) engine InnoDB; 

  

  

  

create table Avis( 

id int auto_increment, 

idClient int, 

idSalle int, 

avis varchar(255), 

note int, 

primary key(id), 

foreign key(idClient) references Client(id) on update cascade on delete cascade, 

foreign key(idSalle) references Salle(id) on update cascade on delete cascade 

)engine InnoDB; 

  

  

  

create table PositionObstacle( 

id int auto_increment, 

nomObstacle varchar(100), 

idReservation int, 

PositionObstacle int check(PositionObstacle <=12), 

primary key(id), 

foreign key(nomObstacle) references Obstacle(nom) on update cascade on delete cascade, 

foreign key(idReservation) references Reservation(id) on update cascade on delete cascade 

)engine InnoDB; 

  

-- INSERT CLIENT  

insert into Client values(1, 'SAHED', 'Thalïa', null, "45 avenue des champs Elysées, 74000, Annecy", "1999-06-19", 'thalia.sahed@saintmichelannecy.fr', '0000000000', 200);  

insert into Client values(2, 'COMBET', 'Hugo', null, "45 avenue des champs Elysées, 74000, Annecy", "2000-01-01", 'hugo.combet@saintmichelannecy.fr', '0000000000', 300);  

insert into Client values(3, 'GROUSSAUD', 'Axel', null, "45 avenue des champs Elysées, 74000, Annecy", "1999-01-01", 'axel.groussaud@saintmichelannecy.fr', '0000000000', 200);  

insert into Client values(4, 'MANCEAU', 'Erwan', null, "45 avenue des champs Elysées, 74000, Annecy", "1994-12-31", 'erwan.manceau@saintmichelannecy.fr', '0000000000', 400);  

insert into Client values(5, 'HORTH', 'William', null, "45 avenue des champs Elysées, 74000, Annecy", "1999-10-01", 'william.horth@saintmichelannecy.fr', '0000000000', 100);  

  

-- INSERT OBSTACLES  

insert into Obstacle values('barrière', 'Ralentit le joueur, il doit la déverouiller', null, null);   

insert into Obstacle values('laser', 'Le joueur ne doit pas toucher les lasers', null, null);   

insert into Obstacle values('coffre-fort', 'Le joueur doit trouver un code pour le déverouiller', null, null);   

insert into Obstacle values('Double-porte', 'Le joueur doit trouver une clef qui la déverouillera', null, null);   

insert into Obstacle values('Trappe', 'Le joueur doit trouver la trappe et attrapper un indice dedans', null, null);   

  

-- INSERT THEMES  

insert into Themes values(1, 'Harry-Potter');  

insert into Themes values(2, 'Football');  

insert into Themes values(3, 'Jungle');  

insert into Themes values(4, 'Sherlock Holmes');  

insert into Themes values(5, 'Forêt enchantée');  

  

-- INSERT SALLE  

insert into Salle values(1, 'Annecy', 1);  

insert into Salle values(2, 'Bonneville', 2);  

insert into Salle values(3, 'Thonon-les-Bains', 3);  

insert into Salle values(4, 'Chamonix', 4);  

  

-- INSERT Transactions  

insert into Transactions values(1, 1, 50);  

insert into Transactions values(2, 2, 70);  

insert into Transactions values(3, 3, 30);  

insert into Transactions values(4, 4, 80);  

insert into Transactions values(5, 5, 70);  

  

-- INSERT RESERVATIONS  

insert into Reservation values(1, 1, "2019-01-01", 7, 12, 1, 1);  

insert into Reservation values(2, 2, "2019-01-01", 5, 2, 2, 2);  

insert into Reservation values(3, 3, "2019-01-01", 5, 7, 3, 3);  

insert into Reservation values(4, 4, "2019-01-01", 6, 9, 4, 4);  

insert into Reservation values(5, 5, "2019-01-01", 7, 11, 1, 5);  

  

-- INSERT AVIS  

insert into Avis values(1, 1, 1, "Excellent thème, je reviendrais !", 5); 

insert into Avis values(2, 2, 2, "Il faut s'y connaître pour pouvoir jouer...", 4); 

insert into Avis values(3, 3, 3, "Totalement immergé dans le thème mais 2 obstacles en panne !", 3); 

insert into Avis values(4, 4, 4, "Je recommande à 100%", 5); 

insert into Avis values(5, 4, 1, "Parfait pour faire participer les enfants aux jeux.", 4); 

  

-- INSERT POSITION OBS 

insert into PositionObstacle values(1, "barrière", 1, 10); 

insert into PositionObstacle values(2, "laser", 2, 12); 

insert into PositionObstacle values(3, "coffre-fort", 3, 4); 

insert into PositionObstacle values(4, "Double-porte", 4, 2); 

insert into PositionObstacle values(5, "Trappe", 5, 7); 