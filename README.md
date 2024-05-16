# Dokumentation 🚙Fordon rapp

## Om appen
Det här är en app som personalen på Varberg kommun kan använda för att rapportera fordonsfel, och rapportering går till bilavdelningen för att hantera fel och brister.

Programmet utvecklades med
・React (se main branch)
・C# .Net 8.0 (se master branch)
・Microsoft SQL

Vad användare gör med appen:

1. Ange användarID
2. Ange registreringsnummer (Rapporthistorik dyker upp automatiskt.)
3. Beskriva fordonsfel i textruta
4. Kryssa in om felet är akut eller inte
5. Skicka in rapport

*Användare blir inloggade automatiskt när hen öppnar appen med jobbmobilen och systemet kan veta vem som har rapporterat. Så användaren behöver bara ange registreringsnummer. Men AnvändarID behöver anges denna gång för att kunna kolla funktioner under utvecklingen.

## Planering
Här redogör jag hur jag ska få en bild av vad som ska göras. Eftersom jag är en del projektet på det befintliga systemet, skriver jag här som om jag redan har en god insikt och förståelse för det befintliga systemet.

1. Tydliggöra målet och syftet
2. Träffa testpersonerna
3. Lista vad som behöver göras
4. Kontakta leverantören
5. Träffa projektledaren innan arbetet påbörjas

1. Tydliggöra målet och syftet
Innan jag börjar att bygga appen, behöver jag förstå vad appen ska användas till. Så för att kunna få en översiktlig bild, vill jag läsa dokumentation om det befintliga systemet och testa det själv också för att kunna samla  tankar och idéer. Sen listas tankar och planer grovt.

2. Att veta krav och förväntningar
Behöver veta konkreta behov och förväntningar från testpersonerna, både vad de vill ha och vad de inte vill ha.

Nedan är frågor som ställdes till testpersonerna:
・Vilka funktioner de vill ha och vad de vill inte ha
	För att veta vad som måste vara med, men också för att inte ha med onödiga funktioner.
・För och nackdelar med det befintliga systemet.
	För att noggrannare hitta vilka funktioner som saknas, och för att se vad som redan fungerar bra.
・Design/layout.
Såsom om de vill ha knappar som man kan välja problem/orsak eller svara i textruta etc. Vad tycker användaren är lättanvänt.
・Hur mycket information de vill kunna se i historiken. 
	Avgöra vad som är lagom mycket information, så det inte blir onödigt mycket.
 
3. Plan enligt svar från testpersoner

・Funktion att ladda upp bild/video
・Visa vilka fel har rapporterats tidigare för att kunna slippa rapportera samma fel igen.
・Textruta för att kunna beskriva problemet i fritext.
・Designen ska vara simpel. Så få fält som måste fyllas i som möjligt. Inlogg etc.
・4 Models: Report, ReportStatus, Vehicle 

4. Kontakta leverantören
Frågor till leverantören är för att kunna veta struktur och funktioner i appen. Vilket språk/API/platform används, 

5. Stämma av med projektledare
Visa planen så här långt så att vi är överens om att jag är på rätt spår.


## Reflektion
Några funktioner som ännu inte implementerats.

・Ladda upp bild/video

・Rapporteringshistorik
Det visas vad användare skrev och sorteras inte innehållet. Det kan skrivs ut en jättelång text.
