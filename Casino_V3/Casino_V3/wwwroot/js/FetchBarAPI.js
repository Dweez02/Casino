// const url kommer fra 'https://the-cocktail-db.p.rapidapi.com/filter.php?i=vodka';
//skrevet primært af Yasmin
// Kalder på API'en 
function getAPI() {
    const options = {
        method: 'GET',
        headers: {
            'X-RapidAPI-Key': 'cbbafa038bmsh3ff7bd4b7c61168p1e7f3ajsna422c7a8f37c',
            'X-RapidAPI-Host': 'the-cocktail-db.p.rapidapi.com'
        }
    };
    let url = 'https://the-cocktail-db.p.rapidapi.com/search.php?s='
    let input = document.getElementById("userInput").value;
    url = url + input;
    let fetchedData;

    fetch(url, options)
        .then(response => response.json())
        .then((data) => {
            console.log(data);
            //arrStrDrink 
            populateDataIntoList(data);
            //window.location.href = "Home/Bar?names=" + ;
        })

        .catch(err => console.error(err))
}

let test = x => x * x;

// Definerer List, som blev lavet i kaldet af API'en

function populateDataIntoList(fetchedData) {
    for (let i = 0; i < 10; i++) {
        let nameDrink = fetchedData.drinks[i].strDrink;
        let listItem = document.createElement('li');
        let textDrink = document.createTextNode(nameDrink);
        listItem.appendChild(textDrink);
        let uList = document.getElementById('list');
        uList.appendChild(listItem);
    }


}