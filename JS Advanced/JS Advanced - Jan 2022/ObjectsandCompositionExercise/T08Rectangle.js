let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());


function rectangle(width, height, color) {
    width = Number(width);
    height = Number(height);
    color = color[0].toUpperCase() + color.slice(1);
    return {
        width,
        height,
        color,
        calcArea() {
            return this.width * this.height;
        }
    }
}