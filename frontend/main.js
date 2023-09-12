window.addEventListener('DOMContentLoaded', (Event) =>{
    getVisitCount();
})

const functionApiURL = 'https://getjamieresumecounter.azurewebsites.net/api/GetResumeCounter?code=G97KzER7p48LHLAKesp5nWsV7Y8F1cX8Jji3S-Q0vAB8AzFuAlvQZA=='
const locolfunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiURL).then(Response => {
        return Response.json()
    }).then(Response =>{
        console.log("Website called function API.");
        count = Response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}