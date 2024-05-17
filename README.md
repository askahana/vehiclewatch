# Dokumentation 🚙Fordon rapp

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

*Användare blir inloggade automatiskt när hen öppnar appen med jobbmobilen och systemet kan veta vem som har rapporterat. Så användaren behöver bara ange registreringsnummer egentligen. Men AnvändarID behöver anges denna gång för att kunna kolla funktioner under utvecklingen.

## Planering
Här redogör jag hur jag ska få en bild av vad som ska göras. Eftersom jag är en del av projektet på det befintliga systemet, har jag redan en god insikt och förståelse för det befintliga systemet.
     
1. Tydliggöra målet och syftet  
Innan jag börjar att bygga appen, behöver jag förstå vad appen ska användas till. Så för att kunna få en översiktlig bild, vill jag läsa dokumentation om det befintliga systemet och testa det själv också för att kunna samla  tankar och idéer. Sen listas tankar och planer grovt.
2. Träffa testpersonerna för att veta krav och förväntningar  
Behöver veta konkreta behov och förväntningar från testpersonerna, både vad de vill ha och vad de inte vill ha.

Nedan är frågor som ställdes till testpersonerna:
- Vilka funktioner de vill ha och vad de vill inte ha  
	➣För att veta vad som måste vara med, och för att inte ha med onödiga funktioner.
- För och nackdelar med det befintliga systemet  
	➣För att noggrannare hitta vilka funktioner som saknas, och för att se vad som redan fungerar bra.
- Design/layout  
	➣Såsom om de vill ha knappar som man kan välja problem/orsak eller svara i textruta etc. Vad användaren tycker är lättanvänt.
- Hur mycket information de vill kunna se i historiken  
	➣Att veta vad lagom mycket information är, så det inte blir onödigt mycket.
 
3. Plan enligt svar från testpersoner/ Lista vad som behöver göras  

Vad som behöver göras ska listas upp för att visualisera arbetet samt börja fundera och designa funktioner och struktur. 

- Frontend: Form behöver användas, input, radiobutton etc.
- Backend: database 4 modeller etc. 
- Funktioner enligt svar från testpersoner
	- ladda upp bild/ video
 	- Visa vilka fel har rapporterats
	- Textruta för att kunna beskriva fordonsfel. 
	- Simpel design. Så få fält som måste fyllas i som möjligt. Inlogg etc.

4. Kontakta leverantören  
Frågor till leverantören är för att kunna veta struktur och funktioner i systemet samt funderingar som dök upp under planeringen.

- Om det finns API som är tillgänglig till nästa app.
- Om det finns några tekniska punkter som jag borde vara medveten om.
  
5. Stämma av med projektledare innan arbetet påbörjas  
Visa planen så här långt så att vi är överens om att jag är på rätt spår.


## Reflektion
Några funktioner som ännu inte implementerats.

- Ladda upp bild/video

- Rapporteringshistorik
Rapporteringhistorik skrivs ut som en lång text nu. Det skulle vara bra om det blir sorterad, identifierad med olika färger beroende på rapporteringsstatus.

・Modal window
Det skulle vara bra om rapportering klart meddelande skrivs ut med modal window.
