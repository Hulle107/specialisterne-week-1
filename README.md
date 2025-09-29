# Specialisterne Week 1

## Kravspecifikation
|  |  |
| ----------- | ----------- |
| **Navn** | Delta Thiesen |
| **Opgave** | Blackjack |
| **Krav/prioriteter** | **Funktionelle krav:** <br> *En spiller skal kunne spille mod en dealer* <br> *En spiller skal kunne ‘hit’ eller ‘stand’* <br> *Der skal implementeres standardregler for blackjack* <br> **Ikke-funktionelle krav:** <br> *Der skal være en visuel fremvisning af kort på bordet* <br> *Der skal være et nemt og forståeligt grafisk interface for spillet* |
| **Kodesprog** | C# |
| **Evt. frameworks** |  |
| **Estimeret tid** | 5 dage |

### Feature List

#### Hovedmenu:

- En menu som bliver vist når programmet er startet
- Et menupunkt (Exit), som lukker programmet
- Et menupunkt (Play), som starter et nyt spil
- Menuen skal kunne navigeres med piletasterne
- Et visuelt fremvisning af den selected menupunkt
- Et ascii title (Blackjack)

#### Kort:

- Et visuelt fremvisning af et kort
- (bagside) En visuel fremvisning af bagsiden af et kort
- (forside) En visuel fremvisning af forsiden af et kort med kortets værdi, farve og type
- Et kort skal kunne blive defineret til enten at ligge skjult eller med værdien fremvist

#### Spilplade:

- Et område med et visuelt fremvisning af spillerens hånd og et visuelt fremvisning af dealerens hånd
- Dealerens hånd vil have et kort som er med bagsiden op, som ikke vil blive vist før resultatet bliver givet

#### Optælling:

- Et område hvor man kan se håndens samlet nuværende værdi

#### En runde:

- En runde indeholder (Spillerens tur) -> (Dealerens tur) -> (Resultat)
- En runde afsluttes altid med at vise (Resultat)

#### Spillerens tur:

- En menu hvor spilleren kan vælge en mulighed mellem ‘Hit’ eller ‘Stand’
- En mulighed (Hit), spilleren bliver givet et nyt kort mere
- En mulighed (Stand), spilleren giver sin tur videre til dealeren
- Mulighederne skal kunne navigeres med piletasterne
- Et visuelt fremvisning af den selected handling
- Hvis spilleren får mere end 21 i værdi afsluttes runden

#### Dealerens tur:

- Dealeren vil prøve at få flere eller samme som spilleren i værdi
- Hvis dealeren får større værdi afslutter dealeren sin tur
- Hvis dealeren får mere end 21 i værdi afsluttes runden

#### Resultat:

- Resultatet bliver fremvist til spilleren
- Hvis spilleren har mindre end dealeren eller højer end 21, fremvises at spilleren har tabt
- Hvis spilleren har mere end dealeren eller dealeren har mere end 21, fremvises at spilleren har vundet
- En menu hvor spilleren kan vælge en mulighed mellem (New round) eller (Back to menu)
- En mulighed (New round), starter en ny runde
- En mulighed (Back to menu), afslutter spillet og returnere til hovedmenuen
- Mulighederne skal kunne navigeres med piletasterne
- Et visuelt fremvisning af den selected mulighed

### Work breakdown

| **Arbejdsopgave** | **Startdato** | **Forventet slutdato** | **Tidsforbrug** |
| ----------- | ----------- | ----------- | ----------- |
| Udarbejdning af Kravspec | 22-09-2025 | 22-09-2025 | 5 timer |
| Udvikling af grundlæggende klasser | 24-09-2025 | 24-09-2025 | 2 timer |
| Implementering af logik | 24-09-2025 | 25-09-2025 | 5 timer |
| Test og kvalitetssikring | 25-09-2025 | 25-09-2025 | 1 time |
| Forberedelse af fremvisning materiale | 25-09-2025 | 25-09-2025 | 2 timer |
| Færdiggørelse af produkt | 25-09-2025 | 25-09-2025 | 1 time |
| Fremlæggelse af produkt | 26-09-2025 | 26-09-2025 | - |
