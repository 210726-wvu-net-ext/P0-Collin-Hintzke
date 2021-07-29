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
echo "Your score is an F"
elif (( $score > 40 && $score < 51 ))
then
echo "Your score is a D"
elif (( $score > 50 && $score < 61 ))
then
echo "Your score is a C"
elif (( $score > 60 && $score < 71 ))
then
echo "Your score is a B"
elif (( $score > 70 ))
then
echo "Your score is an A"
fi
