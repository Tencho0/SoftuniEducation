window.addEventListener("load", solve);

function solve() {
  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');
  let formBtn = document.getElementById('form-btn');
  formBtn.addEventListener('click', addToPreviewList);
  let previewList = document.getElementById('preview-list');
  let mainDiv = document.getElementById('main');

  function addToPreviewList(e) {
    e.preventDefault();
    formBtn.setAttribute('disabled', true);

    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let genreValue = genre.value;
    let storyTitleValue = storyTitle.value;
    let storyValue = story.value;

    if (!firstName.value || !lastName.value || !age.value || !storyTitle.value || !story.value) {
      return;
    }

    let li = document.createElement('li');
    li.classList.add('story-info');
    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = `Name: ${firstName.value} ${lastName.value}`;
    let pAge = document.createElement('p');
    pAge.textContent = `Age: ${age.value}`;
    let pTitle = document.createElement('p');
    pTitle.textContent = `Ttitle: ${storyTitle.value}`;
    let pGenre = document.createElement('p');
    pGenre.textContent = `Genre: ${genre.value}`;
    let pStory = document.createElement('p');
    pStory.textContent = story.value;

    article.appendChild(h4);
    article.appendChild(pAge);
    article.appendChild(pTitle);
    article.appendChild(pGenre);
    article.appendChild(pStory);

    let saveStoryBtn = document.createElement('button');
    saveStoryBtn.classList.add('save-btn');
    saveStoryBtn.textContent = 'Save Story';
    saveStoryBtn.addEventListener('click', saveTheStory);
    saveStoryBtn.disabled = false;
    let editStoryBtn = document.createElement('button');
    editStoryBtn.classList.add('edit-btn');
    editStoryBtn.textContent = 'Edit Story';
    editStoryBtn.addEventListener('click', editTheStory);
    editStoryBtn.disabled = false;
    let deleteStoryBtn = document.createElement('button');
    deleteStoryBtn.classList.add('delete-btn');
    deleteStoryBtn.textContent = 'Delete Story';
    deleteStoryBtn.addEventListener('click', deleteTheStory);
    deleteStoryBtn.disabled = false;

    li.appendChild(article);
    li.appendChild(saveStoryBtn);
    li.appendChild(editStoryBtn);
    li.appendChild(deleteStoryBtn);
    previewList.appendChild(li);

    firstName.value = '';
    lastName.value = '';
    age.value = '';
    storyTitle.value = '';
    story.value = '';

    function editTheStory(e) {
      formBtn.disabled = false;
      saveStoryBtn.disabled = true;
      editStoryBtn.disabled = true;
      deleteStoryBtn.disabled = true;

      li.remove();

      firstName.value = firstNameValue;
      lastName.value = lastNameValue;
      age.value = ageValue;
      storyTitle.value = storyTitleValue;
      story.value = storyValue;
      genre.value = genreValue;
    }

    function saveTheStory(e) {
      // mainDiv.remove();
      // let body = document.getElementsByClassName('body')[0];
      // let newmainDiv = document.createElement('div');
      // newmainDiv.id = 'main';
      // let h1InMainDiv = document.createElement('h1');
      // h1InMainDiv.textContent = 'Your scary story is saved!';
      // newmainDiv.appendChild(h1InMainDiv);
      // body.appendChild(newmainDiv);

      
      var child = mainDiv.lastElementChild;
      while (child) {
        mainDiv.removeChild(child);
        child = mainDiv.lastElementChild;
      }

      let h1InMainDiv = document.createElement('h1');
      h1InMainDiv.textContent = 'Your scary story is saved!';
      mainDiv.appendChild(h1InMainDiv);
    }

    function deleteTheStory(e) {
      li.remove();
      formBtn.disabled = false;
    }
  }
}
