// function focused() {
//     let sectionElements = document.querySelectorAll('body div');

//     Array.from(sectionElements.getElementsByTagName('input')).forEach(el => {
//         el.addEventListener('focus', (e) => {
//             e.target.parentNode.classList.add('focused');
//         });
//     });

//     Array.from(sectionElements.getElementsByTagName('input')).forEach(el => {
//         el.addEventListener('blur', (e) => {
//             e.target.parentNode.classList.remove('focused');
//         });
//     });
// }

function focused() {
    let mainDiv = document.getElementsByTagName("div")[0];

    Array.from(mainDiv.getElementsByTagName("input")).forEach(element => {
        element.addEventListener("focus",focus);
    });

    Array.from(mainDiv.getElementsByTagName("input")).forEach(element => {
        element.addEventListener("blur",focusLost);
    });


    function focus(e) {
        let parent = e.target.parentNode;
       parent.classList.add("focused");
    }


    function focusLost(e) {
        let parent = e.target.parentNode;
       parent.classList.remove("focused");
    }

 }
