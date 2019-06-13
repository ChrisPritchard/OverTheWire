# Natas 31

To see the site:

1. Go to [http://natas31.natas.labs.overthewire.org](http://natas31.natas.labs.overthewire.org)
2. Log in with natas31, hay7aecuungiuKaezuathuk9biin0pu1

Another exploit based on idiot perl doing idiot things, in this case the fact that its `upload` CGI upload function and subsequent type assignment can be trivially bypassed (pass the param name twice, first with a string and last with an actual file, and you'll end up with the string not the file) and that the file parse syntax `<>` will, if it contains the string `ARGV`, proceed to load the query string values as if they were filenames for some fucking stupid reason.

Note: this challenge and the one previous seem to be taken directly from the black hat talks Perl Jam 2 and Perl Jam by Netanel Rubin. Fun talks. Dumb programming language.

3. To get the password, run the script [natas31exploit.fsx](./natas31exploit.fsx).