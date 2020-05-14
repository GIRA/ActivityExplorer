function Storage(){
  if(typeof(Storage)!="undefined")
  {

        var title= document.getElementById("title");
        var age= document.getElementById("slider");
        var area= document.getElementById("area");
        var naps= document.getElementById("naps");
        var time= document.getElementById("time");
        var resume= document.getElementById("resume");
        var desc= document.getElementById("desc");

        localStorage.setItem("Title", title.value);
        localStorage.setItem("Age", age.value);
        localStorage.setItem("Area", area.value);
        localStorage.setItem("Naps", naps.value);
        localStorage.setItem("Time", time.value);
        localStorage.setItem("Resume", resume.value);
        localStorage.setItem("Description", desc.value);

  }
  else{
      alert("El browser no soporta LocalStorage");
  }   
}
function ReStorage(){
  if(typeof(Storage)!="undefined")
  {

        var title= document.getElementById("title");
        var age= document.getElementById("slider");
        var area= document.getElementById("area");
        var naps= document.getElementById("naps");
        var time= document.getElementById("time");
        var resume= document.getElementById("resume");
        var desc= document.getElementById("desc");

        title.value=localStorage.getItem("Title");
        age.value=localStorage.getItem("Age");
        area.value=localStorage.getItem("Area", area.value);
        naps.value=localStorage.getItem("Naps", naps.value);
        time.value=localStorage.getItem("Time", time.value);
        resume.value=localStorage.getItem("Resume", resume.value);
        desc.value= localStorage.getItem("Description", desc.value);

  }
  else{
      alert("El browser no soporta LocalStorage");
  }   
}