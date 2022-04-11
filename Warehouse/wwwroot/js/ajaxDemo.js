const Init = function () {
    let button = document.getElementById("dataLoader");
    let list = document.getElementById("dataContainer");

    button.onclick = function (e) {
        e.preventDefault();
        fetch("/Home/GetData")
            .then(response => response.json())
            .then(data => {
                list.appendChild(CreateLi(`Name: ${data.name}`));
                list.appendChild(CreateLi(`Age: ${data.age}`));
                list.appendChild(CreateLi(`Gender: ${data.gender}`));
                list.appendChild(CreateLi(`Nationality: ${data.nationality}`));
            });
    }
};

const CreateLi = function (txt) {
    let li = document.createElement("li");
    li.appendChild(document.createTextNode(txt));

    return li;
}

window.onload = Init();