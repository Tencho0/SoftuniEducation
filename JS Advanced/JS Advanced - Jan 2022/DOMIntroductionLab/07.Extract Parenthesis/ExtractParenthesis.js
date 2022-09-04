function extract(content) {
    let element = document.getElementById(content);
    let pattern = /\(([^(]+)\)/g;
    let matches = element.textContent.matchAll(pattern);
    let result = [];
    for (const match of matches) {
        result.push(match[1]);
    }
    
    return result.join('; ');
}