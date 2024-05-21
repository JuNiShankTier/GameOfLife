let Generation = 0;

async function setup() {
    let inputWidthElement = document.getElementById('fieldWidth');
    let inputHeightElement = document.getElementById('fieldHeight');
    Generation = 0;
    await fetch('https://localhost:7166/fieldinit?' + new URLSearchParams({
        width: inputWidthElement.value,
        height: inputHeightElement.value
    }).toString(), { method: 'POST' });
    await getField();
}

async function next() {
    await fetch('https://localhost:7166/nextfieldgeneration', { method: 'POST' });
    Generation += 1;
    await getField();
}

async function getField() {
    let response = await fetch('https://localhost:7166/field');

    if (response.ok) { // if HTTP-status is 200-299
        // get the response body (the method explained below)
        let field = await response.json();
        setLabels(field.size.width, field.size.height);
        let fieldElement = document.getElementById('field');
        fieldElement.style.width = field.size.width * 15 + 'px';
        fieldElement.style.gridTemplateColumns = 'repeat(' + field.size.width + ', 1fr)';
        fieldElement.style.gridTemplateRows = 'repeat(' + field.size.height + ', 1fr)';
        fieldElement.replaceChildren();
        field.cells.forEach((value, index) => {
            let div = document.createElement("div");
            div.id = 'cell' + index;
            div.className += 'cell';
            if (value.state == 1) div.className += ' active';
            fieldElement.appendChild(div);
        });
    } else {
        alert("HTTP-Error: " + response.status);
    }
}

function setLabels(width, height) {
    let genElement = document.getElementById('gen');
    let inputWidthElement = document.getElementById('fieldWidth');
    let inputHeightElement = document.getElementById('fieldHeight');
    genElement.textContent = Generation;
    inputWidthElement.value = width;
    inputHeightElement.value = height;
}
setup();