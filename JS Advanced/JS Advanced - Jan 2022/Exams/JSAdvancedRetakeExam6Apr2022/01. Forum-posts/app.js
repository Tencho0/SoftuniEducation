window.addEventListener("load", solve);

function solve() {
  function solve() {
    const titleInputEl = document.getElementById("post-title");
    const categoryInputEl = document.getElementById("post-category");
    const contentInputEl = document.getElementById("post-content");
    const reviewUlEl = document.getElementById("review-list");
    const publishedUlEl = document.getElementById("published-list");
    const reviewMessage = document.getElementById("reviewed-msg");
    const uploadedMessage = document.getElementById("approved-msg");
    document.getElementById("clear-btn").addEventListener("click", clearPosts);
    const submitButtonEl = document
      .getElementById("publish-btn")
      .addEventListener("click", (ev) => {
        if (
          titleInputEl.value !== "" &&
          categoryInputEl.value !== "" &&
          contentInputEl.value !== ""
        ) {
          addPost(
            ev,
            titleInputEl.value,
            categoryInputEl.value,
            contentInputEl.value
          );
          clearInputFileds();
        }
      });

    function addPost(ev, titleInputEl, categoryInputEl, contentInputEl) {
      // ev.preventDefault();

      const li = elGenerator("li");
      li.setAttribute("class", "rpost");
      const article = elGenerator("article", "", li);
      elGenerator("h4", `${titleInputEl}`, article);
      elGenerator("p", `Category: ${categoryInputEl}`, article);
      elGenerator("p", `Content: ${contentInputEl}`, article);

      const approveBtn = elGenerator("button", "Approve", li);
      approveBtn.setAttribute("class", "action-btn approve");
      // approveBtn.setAttribute("class", "approve");
      const editBtn = elGenerator("button", "Edit", li);
      editBtn.setAttribute("class", "action-btn edit");
      // editBtn.setAttribute("class", "edit");

      reviewUlEl.appendChild(li);

      if (reviewUlEl.children.length !== 0) {
        reviewMessage.style.display = "none";
      }

      approveBtn.addEventListener("click", (ev) => approvePost(ev, article));
      editBtn.addEventListener("click", (ev) =>
        editPost(ev, titleInputEl, categoryInputEl, contentInputEl)
      );
    }

    function editPost(ev, _titleInputEl, _categoryInputEl, _contentInputEl) {
      ev.target.parentNode.remove();

      titleInputEl.value = _titleInputEl;
      categoryInputEl.value = _categoryInputEl;
      contentInputEl.value = _contentInputEl;
    }

    function approvePost(ev, articleEl) {
      ev.target.parentNode.remove();

      const publishedLiEl = document.createElement("li");
      publishedLiEl.className = "rpost";
      publishedLiEl.appendChild(articleEl);
      publishedUlEl.appendChild(publishedLiEl);

      if (publishedUlEl.children.length !== 0) {
        uploadedMessage.style.display = "none";
      }

      if (reviewUlEl.children.length == 0) {
        reviewMessage.style.display = "block";
      }
    }

    function clearPosts() {
      // if (publishedUlEl.children.length > 0) {
      //   publishedUlEl.innerHTML = "";
      //   uploadedMessage.style.display = "block";
      // }
      let postsArray = Array.from(publishedUlEl.children);
      postsArray.forEach((post) => {
        post.remove();
      });
      if (publishedUlEl.children.length == 0) {
        uploadedMessage.style.display = "block";
      }
    }

    function clearInputFileds() {
      titleInputEl.value = "";
      categoryInputEl.value = "";
      contentInputEl.value = "";
    }

    function elGenerator(type, content, parent) {
      const element = document.createElement(type);
      element.textContent = content;

      if (parent) {
        parent.appendChild(element);
      }
      return element;
    }
  }
}
