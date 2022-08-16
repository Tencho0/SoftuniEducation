function stringLengthFuction(firstInput, secondInput, thirdInput){
   let result;
   if(firstInput> secondInput && firstInput > thirdInput){
    result = firstInput;
   }else if(secondInput > firstInput && secondInput > thirdInput){
result = secondInput;
   }
   else{
    result = thirdInput;
   }
   console.log("The largest number is " + result + '.');
}