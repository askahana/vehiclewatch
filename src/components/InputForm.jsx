import React, { useState, useEffect } from 'react'
import {useForm} from "react-hook-form"

const InputForm = () => {

  const {register, handleSubmit,   formState: { errors },} = useForm({mode:"onSubmit"}); 
  // För att visa ett meddelande om rappotern har lyckats eller inte.
  const [resultMessage, SetResultMessage] = useState("");
// Den här används för att visa olika meddelande, såsom historik etc.
  const [vehiclestatus, setVehicleStatus] = useState(null);
// För att hämta användarens input på registrerings nummer.
  const [carNum, setCarNum] = useState("");

// ändrar registreingnummer till vehicleID
  const fetchVehicleId = async (carNum) => {
    try { /**Behöver ändra addressen beroende på adressen. */
      const vehicleResponse = await fetch(`https://localhost:7060/api/Vehicle/${carNum}`);
      const vehicleId = await vehicleResponse.json();
      if (!vehicleId || vehicleId === 0) {
        console.error("Reg.nr. finns inte");
        setVehicleStatus("Reg.nr. finns inte");
        return null;  
      }
      return vehicleId;
    } catch (error) {
      console.error("Error fetching vehicle ID:", error);
      setVehicleStatus("Error fetching vehicle ID");
      return null;  
    }
  };


  const handleChange = (e) =>{
    setCarNum(e.target.value);
    setVehicleStatus("");    
  }
  // Det här funktionen är för att ändra datum format.
  function changedateFormate(date){
    return date.toString().split('T')[0];
  }
 // Funktion som returnerar array berående på status
function getStatusMessage(status){
  const messageInProgress = "Pågår";
  const messageRepaired = "Repererat";
  const messageCompleted = "Klart";
  const messages = [messageInProgress, messageRepaired, messageCompleted];

 return status.map(sta=>{
    switch(sta){
      case 0:
        return messageInProgress;
      case 1:
        return messageRepaired;
      case 2:
        return messageCompleted;
      default:
        return "NA";
    }
  })
  
}
    // Hämta API för att visa rapporteringshistorik.
  useEffect(() =>{
    const fetchData = async () => {
     if(carNum){
try{
  /**Behöver ändra addressen beroende på adressen. */
  const vehicleId = await fetchVehicleId(carNum);
  if (!vehicleId) return;
  const response = await fetch(`https://localhost:7060/api/Report/${vehicleId}`)
  const data = await response.json();
  if(Array.isArray(data)  && data.length > 0){
    data.forEach(report => {
      const descriptions = data.map(report => report.reportDescription);
      const reportedDates = data.map(report => report.reportedDate);
      const status = data.map(report => report.reportStatus);
     /* console.log(descriptions);
      console.log(reportedDates);
      console.log(status);*/
      const statusMessage = getStatusMessage(status);
      console.log(getStatusMessage(status));
     
      const descritptionReversed =  descriptions.reverse();
      const datesWithNewLineReversed = reportedDates.reverse();
      const changeddates = datesWithNewLineReversed.map(changedateFormate);
      console.log(changeddates);

      const combinedArray = changeddates.map((date, index) => `${date}: ${descriptions[index]}${statusMessage[index]}`);
      const vehicleStatus =  combinedArray.join("\n");/*`${changeddates}${descritptionReversed}${statusMessage}`;*/
      setVehicleStatus(vehicleStatus);
    })
  }else{
    console.log("Ingen info.");
    setVehicleStatus("Ingen info.");
  }
 
}catch(error){
  setVehicleStatus("Could not fetch the car.");
  console.error("Error to fetch data", error);
}}
    };
    fetchData();
    },[carNum]);

    const onSubmit = async (data) => {
      try {
        const vehicleId = await fetchVehicleId(carNum);
        if (!vehicleId) return;
        data.vehicleId = vehicleId;
        console.log(" ID: "+ vehicleId);
        data.emergency = data.emergency === 'true';
        data.reportedDate = new Date();
        const response = await fetch('https://localhost:7060/api/Report', {
          method: "POST",
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(data)
        });
        console.log(data);
        if (response.ok) {
          console.log("Rapporterat");
          SetResultMessage("Rapporterat!");
        } else {
          console.error("Kunde inte rapportera:", response.statusText);
          SetResultMessage("Kunde inte rapportera.");
        }
      } catch (error) {
        console.error("Error:", error);
      }
    };

  return (
    <div >
        <form onSubmit = {handleSubmit(onSubmit)}>
            <label htmlFor="employeeId">AnvändarID</label>
            <input id = "employeeId" type="text" name = "employeeId" {...register("employeeId", {required: "Ange använderid.", valueAsNumber: true})}/>
            <p>{errors.employeeId?.message}</p>
            <label htmlFor="registrationNumber">Registeringsnummer</label>
            <input id= "registrationNumber" type="text" name = "registrationNumber" {...register("registrationNumber", {required: "Ange registrerings nummer."})}
              value = {carNum} onChange = {(e) => handleChange(e)}/>
              <p>{errors.registrationNumber?.message}</p> 
            <label htmlFor="emergency">Akut</label>
            <div className="radioButton">
            <input id= "answer-ja" className = "radioElement" type="radio" value={true} name="emergency" {...register("emergency", {required: "Vänligen välj", valueAsBoolean: true})}/>Ja
            <input id= "answer-nej" className = "radioElement" type="radio" value={false} name="emergency" {...register("emergency", {required: "Vänligen välj", valueAsBoolean: true})}/>Nej
            </div>
            <p>{errors.emergency?.message}</p>
            <label htmlFor="reportDescription">Fel</label>
            <textarea name="reportDescription" id="" placeholder="Ange text" {...register("reportDescription", {required: "Ange text"})}></textarea>
            <p>{errors.reportDescription?.message}</p>
            <button type="submit" className="submitBtn">Submit</button>
            <p className="result">{resultMessage}</p>
            <label htmlFor="status">Historik</label>
            {vehiclestatus?  
            (vehiclestatus.split('\n').map((line, index) => (
                <p className ="carstatus" key={index}>{line}</p>
              )))  :( <p className="carstatus"></p>)}
        </form>

    </div>
  )
}

export default InputForm