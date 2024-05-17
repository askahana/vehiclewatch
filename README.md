# Fordon rapp🚙

## Om appen
Det här är en app som personalen på Varberg kommun kan använda för att rapportera fordonsfel, och rapportering går till bilavdelningen för att hantera fel och brister.

Programmet utvecklades med
- React (se main branch)
- C# .Net 8.0 (se master branch)
- Microsoft SQL

Vad användare gör med appen:

1. Ange användarID
2. Ange registreringsnummer (Rapporthistorik dyker upp automatiskt.)
3. Beskriva fordonsfel i textruta
4. Kryssa in om felet är akut eller inte
5. Skicka in rapport
   
<img src="https://github.com/askahana/vehiclewatch/assets/144675449/a6a927a8-0511-4c04-9f5f-999b2954ef39" alt="Vehicle Image" width="300" height="200">
*Användare blir inloggade automatiskt när hen öppnar appen med jobbmobilen och systemet kan veta vem som har rapporterat. Så användaren behöver bara ange registreringsnummer egentligen.  

## Planering(Uppgift 1)
Här redogör jag hur jag ska få en bild av vad som ska göras. Eftersom jag är en del av projektet på det befintliga systemet, har jag redan en god insikt och förståelse för det befintliga systemet.
     
1. **Tydliggöra målet och syftet**   
Innan jag börjar att bygga appen, behöver jag förstå syftet med den. Så för att kunna få en översiktlig bild, vill jag läsa dokumentation om det befintliga systemet och testa det själv också för att kunna samla tankar och idéer. Sen listas tankar och planer grovt.  

2. **Träffa testpersonerna för att veta krav och förväntningar**   
Behöver veta konkreta behov och förväntningar från testpersonerna, både vad de vill ha och vad de inte vill ha.

Nedan är frågor som ställdes till testpersonerna:
- Vilka funktioner de vill ha och vad de vill inte ha  
	➣ För att veta vad som måste vara med, och för att inte ha med onödiga funktioner.
- För och nackdelar med det befintliga systemet  
	➣ För att noggrannare hitta vilka funktioner som saknas, och för att se vad som redan fungerar bra.
- Design/layout  
	➣ Såsom om de vill ha knappar som man kan välja problem/orsak eller svara i textruta etc. Vad användaren tycker är lättanvänt.
- Hur mycket information de vill kunna se i historiken  
	➣ För att veta lagom mycket information, så det inte blir onödigt mycket.
 
3. **Plan enligt svar från testpersoner**

Vad som behöver göras ska listas upp för att visualisera arbetet samt börja fundera och designa funktioner och struktur. 

- Frontend: Formulär, input, radiobutton etc.
- Backend: database 4 modeller, API endpoints för att hantera rapporter etc. 
- Funktioner enligt svar från testpersoner
	- ladda upp bild/ video
 	- visa vilka fel har rapporterats med datum
	- textruta för att kunna beskriva fordonsfel. 
	- simpel design. så få fält som måste fyllas i som möjligt.

4. **Kontakta leverantören**  
Tekniska frågor för att kunna veta struktur och funktioner i systemet samt funderingar som dök upp under planeringen ska ställas.
	
- Kopplingar mellan olika delsystem
 ➣ Ta reda på nödvändig info om system/databaser för att möjliggöra automatisk inloggning.
- Om det finns något som kan användas till appen, såsom API
- Om det finns några tekniska punkter som jag borde vara medveten om
- Vad jag borde vara medveten om när jag bygger app, hantera säkerhet.  

5. **Stämma av med projektledare innan arbetet påbörjas**  
Visa planen så här långt så att vi är överens om att jag är på rätt spår.


## Reflektion
Några funktioner som ännu inte implementerats.

- Ladda upp bild/video

- Rapporteringhistorik skrivs ut som en lång text nu. Det skulle vara bra om det blir sorterad, identifierad med olika färger beroende på rapporteringsstatus.

- Modal window för att visa meddelade om rapporteringen är klar. Och meddelade borde variera när det inte gick, såsom fel med registreringsnummer etc.
