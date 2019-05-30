#!/usr/bin/expect -f

spawn ssh -l bandit16 -p 2220 bandit.labs.overthewire.org
expect "*: "
send "cluFn7wTiGryunymYOu4RcffSxQluehd\r"
expect "*\$ "

send "nmap -p 31000-32000 localhost | grep /tcp | cut -c 1-5\r"
expect "*\$ "

send "echo cluFn7wTiGryunymYOu4RcffSxQluehd | openssl s_client -quiet -host localhost -port 31790\r"
expect "*\$ "

send "exit\r"
