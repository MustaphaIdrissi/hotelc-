create database ZAIKAY

use ZAIKAY



/*creation table 

create table Hotel(
 HOT_ID int primary key identity ,
 HOT_NOM varchar(255),
 HOT_SITUATION varchar(255),
 HOT_NBR_ETOILES int,
)


insert into Hotel (HOT_NOM,HOT_SITUATION,HOT_NBR_ETOILES)values('Résidence Ifrane','Rue Bir Anzarane Bd Mly Abdellah, 53100 Ifrane, Maroc',4)
insert into Hotel (HOT_NOM,HOT_SITUATION,HOT_NBR_ETOILES)values('dar silsila','11, Derb Jdid Laksour, Médina, 40000 Marrakech, Maroc',4)
insert into Hotel (HOT_NOM,HOT_SITUATION,HOT_NBR_ETOILES)values('Michlifen Resort & Golf','Bp 18 Hassan II, 53000 Ifrane, Maroc',5)
insert into Hotel (HOT_NOM,HOT_SITUATION,HOT_NBR_ETOILES)values('ZEPHYR ','Quartier Belle Vu, Ifrane, Morocco, 53000 Ifrane, Maroc',3)


create table Client(
CLI_ID int primary key identity ,
TITRE varchar(255),
NOM  varchar(255),
PRENOM varchar(255),
ADRESSE varchar(255),
VILLE varchar(255)
)
insert into Client (TITRE,NOM,PRENOM,ADRESSE,VILLE)values('titre1','ahmed','Hilali','Fes','fes')
insert into Client (TITRE,NOM,PRENOM,ADRESSE,VILLE)values('titre2','said','abda','atlas azrou','azrou')
insert into Client (TITRE,NOM,PRENOM,ADRESSE,VILLE)values('titre3','khalid','karouxe','hamriy','meknes')
insert into Client (TITRE,NOM,PRENOM,ADRESSE,VILLE)values('titre4','kamal','idri','jarf','casa blanca')



create table Categorie(
CAT_ID int primary key identity ,

DESIGNATION varchar(255),

TARIF_PERSONNE  varchar(255),


)

insert into Categorie (DESIGNATION,TARIF_PERSONNE)values('suites',400)
insert into Categorie (DESIGNATION,TARIF_PERSONNE)values( 'Chambre ',150)
insert into Categorie (DESIGNATION,TARIF_PERSONNE)values('Chambre Double',200)
insert into Categorie (DESIGNATION,TARIF_PERSONNE)values('Appartement',500)


create table Chambre (

CHB_ID int primary key identity ,
CHB_NUMERO int ,
CHB_ETAGE int,
NBR_LITS int ,
HOT_ID int,
CAT_ID int,
foreign key(HOT_ID) references Hotel(HOT_ID),

foreign key(CAT_ID) references Categorie(CAT_ID),
)


insert into Chambre (CHB_NUMERO,CHB_ETAGE,NBR_LITS,HOT_ID,CAT_ID)values(1,2,2,1,1)
insert into Chambre (CHB_NUMERO,CHB_ETAGE,NBR_LITS,HOT_ID,CAT_ID)values(4, 3,1,3,3)
insert into Chambre (CHB_NUMERO,CHB_ETAGE,NBR_LITS,HOT_ID,CAT_ID)values(5,3,1,2,2)
insert into Chambre (CHB_NUMERO,CHB_ETAGE,NBR_LITS,HOT_ID,CAT_ID)values(3,2,2,4,1)




create table Reservation (
RES_ID int primary key identity ,
NBR_PERSONNES  int,
DATE_RESERVATION date, 
DATE_ARRIVEE date, 
DATE_DEPART date,
CLI_ID int,
CHB_ID int ,

foreign key(CLI_ID) references Client(CLI_ID),

foreign key(CHB_ID) references Chambre(CHB_ID),


)

drop table Reservation



insert into Reservation (NBR_PERSONNES,DATE_RESERVATION,DATE_ARRIVEE,DATE_DEPART,CLI_ID,CHB_ID)values(1,'12/08/2021','15/08/2021','15/09/2021',1,3)
insert into Reservation (NBR_PERSONNES,DATE_RESERVATION,DATE_ARRIVEE,DATE_DEPART,CLI_ID,CHB_ID)values(2,'1/08/2021','5/08/2021','15/08/2021',3,1)
insert into Reservation (NBR_PERSONNES,DATE_RESERVATION,DATE_ARRIVEE,DATE_DEPART,CLI_ID,CHB_ID)values(4,'12/07/2021','5/08/2021','5/09/2021',2,4)
insert into Reservation (NBR_PERSONNES,DATE_RESERVATION,DATE_ARRIVEE,DATE_DEPART,CLI_ID,CHB_ID)values(1,'17/09/2021','19/09/2021','20/09/2021',4,2)


*/


---2---
select * from Client order by  NOM,PRENOM ASC

----3---


select c.* from Client C inner join Reservation r on r.CLI_ID=c.CLI_ID where DATENAME(mm,r.DATE_RESERVATION)='décembre'




----4---


select HOT_NOM,DESIGNATION,DATE_RESERVATION,DATE_ARRIVEE     from Reservation r inner join Chambre c on r.CHB_ID=c.CHB_ID


inner join Hotel h on h.HOT_ID=c.HOT_ID 

inner join Categorie ct on c.CAT_ID=ct.CAT_ID 



----5------
select HOT_NOM,DESIGNATION,DATE_RESERVATION,DATE_ARRIVEE , DATE_DEPART ,
CAST(DATEDIFF(dd,DATE_ARRIVEE,DATE_DEPART)*TARIF_PERSONNE*0.5 as float)as 'tariff' ,
DATEDIFF(dd,DATE_ARRIVEE,DATE_DEPART)as'jour'   


from Reservation r
 inner join Chambre c on r.CHB_ID=c.CHB_ID
 inner join Hotel h on h.HOT_ID=c.HOT_ID 
 inner join Categorie ct on c.CAT_ID=ct.CAT_ID 
 
 where MONTH(r.DATE_RESERVATION)in(select MONTH(getdate()) from Reservation )
and DATEDIFF(dd,DATE_ARRIVEE,DATE_DEPART)>=10



------6-----
select * from Client where nom like '%er' and nom  NOT LIKE '%a%' and nom  NOT LIKE '%A%' and nom  NOT LIKE '%o%' and nom  NOT LIKE '%O%'

----7--------


select DESIGNATION,COUNT(DATE_RESERVATION)  from Reservation r inner join Chambre c on r.CHB_ID=c.CHB_ID
inner join Categorie ct on c.CAT_ID=ct.CAT_ID 
group by(DESIGNATION)



------9-----
select ht.HOT_NOM,DESIGNATION,COUNT(DATE_RESERVATION)AS 'plus réservée'  from Reservation r inner join Chambre c on r.CHB_ID=c.CHB_ID
inner join Categorie ct on c.CAT_ID=ct.CAT_ID inner join Hotel ht on ht.HOT_ID=c.HOT_ID
group by ct.DESIGNATION,ht.HOT_NOM


----10-------



select ht.HOT_NOM,c.CHB_NUMERO,COUNT(c.CHB_NUMERO)as 'Nbr reservation'

from Reservation r 
inner join Chambre c on r.CHB_ID=c.CHB_ID
inner join Hotel ht on ht.HOT_ID=c.HOT_ID
where DATENAME(mm,r.DATE_RESERVATION) IN (select DATENAME(MM,DATE_RESERVATION) from Reservation where 2021=DATENAME(yy,DATE_RESERVATION))


group by ht.HOT_NOM,c.CHB_NUMERO
HAVING COUNT(c.CHB_NUMERO) >=2






