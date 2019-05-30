#!/usr/bin/expect -f

spawn ssh -l bandit17 -p 2220 -i bandit17.key bandit.labs.overthewire.org
expect "*\$ "

#send "nmap -p 31000-32000 localhost | grep /tcp | cut -c 1-5\r"
#expect "*\$ "

#send "echo cluFn7wTiGryunymYOu4RcffSxQluehd | openssl s_client -quiet -host localhost -port 31790\r"
#expect "*\$ "

#send "exit\r"
