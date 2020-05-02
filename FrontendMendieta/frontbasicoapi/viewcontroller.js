function ComponentInitialization(){

    let TextBox= document.getElementById("TextBox");
    let TextBox2= document.getElementById("TextBox2");
    let BtnGet= document.getElementById("BtnGet");
    let BtnGetId= document.getElementById("BtnGetId");
    let BtnAdd= document.getElementById("BtnAdd");
    let BtnMod= document.getElementById("BtnMod");    
    let BtnDelete= document.getElementById("BtnDelete");
    let actions=requestHandler();
    let tabla= document.getElementById("table");
    let exampleActivity={"Id":"6","Area":"Educación","Titulo":"Insertar robots","Descripcion":"Inserción de la robótica en el Aula","Duracion":"60 hrs"};

    BtnGet.addEventListener("click",function()
    {
        let result=actions.getActivities();
        result.then(function(res){
            console.log(res);
        })
        /*res.map((arg)=>{
                     
        });*/
        
    });
    function CreateRow(){
        var row= document.createElement("TR");

        var cell= document.createElement("TD");

        cell.appendChild(document.createTextNode(arg.Id));
        cell.appendChild(document.createTextNode(arg.Author));
        cell.appendChild(document.createTextNode(arg.Area));
        cell.appendChild(document.createTextNode(arg.Title));
        cell.appendChild(document.createTextNode(arg.Institution));
        cell.appendChild(document.createTextNode(arg.AgeMin));
        cell.appendChild(document.createTextNode(arg.AgeMax));
        cell.appendChild(document.createTextNode(arg.ShortDescp));       
        cell.appendChild(document.createTextNode(arg.Description));
        cell.appendChild(document.createTextNode(arg.PublishingDate));
        cell.appendChild(document)
        cell.appendChild(document.createTextNode(arg.Duration));
        cell.appendChild(document.createTextNode(arg.Files));
        
        row.appendChild(cell);
        tabla.appendChild(row);
        document.body.insertAdjacentElement('beforeend', tabla);
    }

    BtnGetId.addEventListener("click",function()
    {        
        let result=actions.getActivityId(TextBox.value);
        result.then(function(res){
        console.log(res);
        //here will be the function that will remake the HTML document
        })
    });
    
    BtnAdd.addEventListener("click",function()
    {       
        let activity=TextBox2.value;
        debugger;
        let result=actions.AddActivity(JSON.parse(activity));
        result.then(function(res){
        console.log(res);
        //here will be the function that will remake the HTML document
        })
    });

    BtnMod.addEventListener("click",function()
    {   
        let Activityid=TextBox.value;
        let activityMod=TextBox2.value;
        let result=actions.ModifyActivity(Activityid,JSON.parse(activityMod));
        debugger;
        result.then(function(res){
        console.log(res);
        //here will be the function that will make the HTML document
        })
    });
    
    BtnDelete.addEventListener("click",function()
    {   
        let Activityid=TextBox.value;
        let result=actions.DeleteActivity(Activityid);
        debugger;
        result.then(function(res){
        console.log(res);
        //here will be the function that will make the HTML document
        })
    });   
}


//{"Id": "1", "Area": "artevisual", "Titulo": "Insertar robots", "Descripcion": "Inserción de la robótica en el Aula", "Duracion": "50 hrs"} para testear las consultas