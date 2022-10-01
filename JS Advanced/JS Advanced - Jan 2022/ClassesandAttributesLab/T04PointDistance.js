class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2) {
        let a = Math.abs(p1.x - p2.x);
        let b = Math.abs(p1.y - p2.y);
        let distance = Math.sqrt(a ** 2 + b ** 2);
        return distance;
    }
}