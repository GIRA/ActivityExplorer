function Save() {
    if (typeof(Storage) != "undefined") {
        var contents = quillEditor.getContents();
        //creating the object
        var object = {
            title: document.getElementById("title").value,
            age: document.getElementById("slider").value,
            area: document.getElementById("area").value,
            naps: document.getElementById("naps").value,
            time: document.getElementById("time").value,
            resume: document.getElementById("resume").value,
            description: JSON.stringify(contents, null, 2)
        };
        //loading the information 
        var stringobject = JSON.stringify(object);
        localStorage.setItem("object", stringobject);

    } else {
        alert("El browser no soporta LocalStorage");
    }
}

function Load() {
    if (typeof(Storage) != "undefined") {
        var get = JSON.parse(localStorage.getItem("object"));
        //elements form
        var title = document.getElementById("title");
        var age = document.getElementById("slider");
        var age2 = document.getElementById("OutputId");
        var area = document.getElementById("area");
        var naps = document.getElementById("naps");
        var time = document.getElementById("time");
        var resume = document.getElementById("resume");
        var description = document.getElementById("editor-container");
        //setted the values from the json
        title.value = get.title;
        age.value = get.age;
        age2.value = get.age;
        area.value = get.area;
        naps.value = get.naps;
        time.value = get.time;
        resume.value = get.resume;
        description = quillEditor.setContents(JSON.parse(get.description));
    } else {
        alert("El browser no soporta LocalStorage");
    }
}