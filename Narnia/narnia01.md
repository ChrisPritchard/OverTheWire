# Narnia 1

Password: `efeidiedae`

Running /narnia/narnia1 gives the message `Give me something to execute at the env-variable EGG`

The source code for the problem is (no license, again):

```C
#include <stdio.h>

int main(){
    int (*ret)();

    if(getenv("EGG")==NULL){
        printf("Give me something to execute at the env-variable EGG\n");
        exit(1);
    }

    printf("Trying to execute EGG!\n");
    ret = getenv("EGG");
    ret();

    return 0;
}
```

I attempted to build something sneaky [like this](./narnia00-failed.c) (compiled with gcc) but it didnt work. Ultimately a bit of research revealed that this is a shellcode problem: the goal is to place into the environment variable some text that is the hex encoding of legitimate machine code, so when the program casts it to a function, the function is valid.

Shellcode is the nickname for position-independent code, machine code that can be placed anywhere in memory and still function as intended. It needs to not depend on any stack variables, and to contain no null values (that is, to not contain the text `\x00`) so that it can function both as a full string and as machine code (the null value would prematurely terminate the string, ruining the shellcode).

While its entirely possible to grab some shellcode online (e.g. from the [shellcode database](http://shell-storm.org/shellcode/)), I took this as a learning challenge and decided to write my own.