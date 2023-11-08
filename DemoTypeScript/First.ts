console.log("This is typescript...")
var firstName:string="Tom"
var age:number=23
console.log("Name:"+firstName)
console.log("Age:"+age)

var fno:number=70
var sno:number=80
var csno:string='40'
console.log(fno+sno+csno)

var fruits:string[]=['apple','Mango','Orange']
for(let i=0;i<fruits.length;i++)
console.log(fruits[i])

function sayHello():void{
    console.log("Hello world")
}

function multiply(a:number,b:number):number{
    return a*b
}

sayHello()
console.log(multiply(2,3))