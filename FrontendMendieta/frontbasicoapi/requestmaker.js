//const entities= require('./entities');

function requestHandler(){
    let operations={};
    const baseURL='https://localhost:44343';//cambiar con el localhost que les levante la api

    operations.getActivities= function()
    {      
        try 
        {
            let result=fetch(baseURL+'/api/Activity')
                .then(function(res){
                    if(res.ok){
                        console.log(res);
                        //console.log(res.body);
                        
                        return res.json();
                    }else{
                        throw 'Nose se pudo hacer la peticion';
                    }
            })
            .catch(function(error){
                console.log(error);       
            }); 
            return result;      
        } 
        catch (error) {         
        }       
    } 
    operations.getActivityId= function(id)
    {      
        try 
        {            
            let result=fetch(baseURL+'/api/Activity/'+id)
                .then(function(res){
                    if(res.ok){
                        console.log(res);                       
                        return res.json();
                    }else{
                        throw 'Nose se pudo hacer la peticion';
                    }
            })
            .catch(function(error){
                console.log(error);       
            }); 
            return result;      
        } 
        catch (error) {         
        }       
    } 

    operations.AddActivity = function(activity) {
        
        return new Promise((resolve,reject)=>{
            let request = new XMLHttpRequest();
            request.open("POST", baseURL + "/api/Activity", true)
            request.setRequestHeader('Accept', 'application/json');
            request.setRequestHeader('Content-type', 'application/json; charset=utf-8');
            let data = JSON.stringify(activity);
            request.send(data);
            request.addEventListener("load", ()=>{
                resolve(data);
            });
        });
    };
    operations.ModifyActivity= function(id,activity) {
        return new Promise((resolve,reject)=>{
            let request = new XMLHttpRequest();
            request.open("PATCH", baseURL + "/api/Activity/" + id, true);
            request.setRequestHeader("Content-Type", "application/json");
            request.setRequestHeader("Accept", "application/json");
    
            let data = JSON.stringify(activity);        
            request.send(data)
            request.addEventListener("load",()=>{
                resolve(request.response);
            });
        });   
    };
    operations.DeleteActivity = function(Id){
        return new Promise((resolve, reject)=>{
            let request = new XMLHttpRequest();
            request.open("DELETE", baseURL + "/api/Activity/"+Id, true);
            request.send(null);
            request.addEventListener("load", ()=>{
                resolve(request.response);
            }); 
        });
        
    };
    return operations;
}
    /*
    operations.AddActivity= function(activity)
    {      
        try 
        {     
            let myInit={
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                  },
                method: 'POST',
                
            };           
            console.log(JSON.stringify(activity));  
            let result=fetch(baseURL+'/api/Activity',myInit)
                .then(function(res){
                    if(res.ok){
                        console.log('Successful Insertion ');
                        
                    }else{
                        throw 'Nose se pudo hacer la peticion';
                    }
            })
            .catch(function(error){
                console.log(error);       
            }); 
            return result;      
        } 
        catch (error) {         
        }       
    } 

    operations.ModifyActivity= function(id,activity)
    {      
        try 
        {     
            let myInit={
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                  },
                method: 'PATCH',
                body:JSON.stringify(activity),
            };           
            console.log(JSON.stringify(activity));  
            let result=fetch(baseURL+'/api/Activity/'+id,myInit)
                .then(function(res){
                    if(res.ok){                    
                        console.log('Successful Modify');                       
                    }else{
                        throw 'Nose se pudo hacer la peticion';
                    }
            })
            .catch(function(error){
                console.log(error);       
            }); 
            return result;      
        } 
        catch (error) {         
        }       
    } 


    operations.DeleteActivity= function(Id)
    {      
        try 
        {     
            debugger;
            let myInit={
                headers: {
                    'Accept': 'application/text',
                    'Content-Type': 'application/text'
                  },
                method: 'DELETE',          
            };           
            let result=fetch(baseURL+'/api/Activity/'+Id)
                .then(function(res){
                    if(res.ok){
                        debugger;
                        console.log('Successful Delete');
                    }else{
                        throw 'Nose se pudo hacer la peticion';
                    }
            })
            .catch(function(error){
                console.log(error);       
            }); 
            return result;      
        } 
        catch (error) {         
        }       
    }*/
        //{"Id": "1", "Area": "", "Titulo": "Insertar robots", "Descripcion": "Inserción de la robótica en el Aula", "Duracion": "60 hrs"}