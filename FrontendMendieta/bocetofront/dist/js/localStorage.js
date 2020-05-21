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
        var age2= document.getElementById("OutputId");
        var area= document.getElementById("area");
        var naps= document.getElementById("naps");
        var time= document.getElementById("time");
        var resume= document.getElementById("resume");
        var desc= document.getElementById("desc");

        title.value=localStorage.getItem("Title");
        age.value=localStorage.getItem("Age");
        age2.value= localStorage.getItem("Age");
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

function QuillStorage(){
  var quill = new Quill('#editor-container', {
    modules: {
        syntax: true,
        toolbar: '#toolbar-container',
    },
    placeholder: 'Write here ...',
    theme: 'snow',
  });
  
  //Save delta content in local storage and show it changes
  container = document.querySelector('#delta-container');
  quill.on('text-change', function(delta) {
    var contents = quill.getContents();
    localStorage.setItem('delta', JSON.stringify(contents, null, 2));
    var html = "contents = " + JSON.stringify(contents, null, 2);
    html = html + "<br>" + "change = " + JSON.stringify(delta, null, 2);
    container.innerHTML = html;
    console.log('contents', contents);
    console.log('change', delta)
  });
  
  //Load the json saved into local storage
  window.onload = function() {;
    quill.setContents(JSON.parse(localStorage.getItem('delta')));
  }
}