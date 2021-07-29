read -p "Please enter a number to check if it is even or odd!  " num
if (( $num % 2 == 0))
then
echo "$num is even"
else
echo "$num is odd"
fi

read -p "Now please enter the score of the test 0-100  " score
if (( $score < 41 ))
then
    echo "F"
elif (( $score < 51 ))
then
    echo "D"
elif (( $score < 61 ))
then
    echo "C"
elif (( $score < 71 ))
then 
    echo "B"
else
    echo "A"
fi