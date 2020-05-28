function Storage(){
  if(typeof(Storage)!="undefined")
  {
        var object={
          title: document.getElementById("title").value,
          age: document.getElementById("slider").value,
          area: document.getElementById("area").value,
          naps: document.getElementById("naps").value,
          time: document.getElementById("time").value,
          resume: document.getElementById("resume").value
        };
        var stringobject= JSON.stringify(object);
        localStorage.setItem("object", stringobject);

  }
  else{
      alert("El browser no soporta LocalStorage");
  }   
}
function ReStorage(){
  if(typeof(Storage)!="undefined")
  {
        var get= JSON.parse(localStorage.getItem("object"));
        //elementos del form
        var tit= document.getElementById("title");
        var age= document.getElementById("slider");
        var age2= document.getElementById("OutputId");
        var area= document.getElementById("area");
        var naps= document.getElementById("naps");
        var time= document.getElementById("time");
        var resume= document.getElementById("resume");
        //setted the values from the json
        tit.value= get.title;
        age.value= get.age;
        age2.value= get.age;
        area.value= get.area;
        naps.value= get.naps;
        time.value= get.time;
        resume.value= get.value;
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