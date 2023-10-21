# Cache Memory
Projekat iz predmeta Elementi razvoja softvera

## Kratak opis projekta :
* Implementirana je konzolna aplikacija koja sadrži 4 komponente (Writer, Dumping Buffer, Historical i Reader).
* Komponenta Writer se koristi za unos podataka preko konzole.
* Komponenta Dumping Buffer privremeno skladišti podatke koji su uneti u Writer komponenti.
* Komponenta Historical radi sa bazom podataka, smešta podatke koje je Dumping Buffer prosledio do nje.
* Komponenta Reader koristi metode iz Historical komponente i ispisuje podatke iz baze podataka na konzolu.

**Za sve detalje pročitati Opis projekta!**

## Tehnologije :
* Konzolna aplikacija je implenetirana u C#
* Baza podataka je implementirana u Microsoft Sql Server 2022