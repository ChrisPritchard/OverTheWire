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

I attempted to build something sneaky like this (compiled with gcc) but it didnt work:

```C
#include <stdio.h>
#include <stdlib.h>

int fun()
{
    system("cat /etc/narnia_pass/narnia2");
    return 0;
}

int main()
{
    setenv("EGG", &fun, 1);
    system("/narnia/narnia1");

    return 0;
}
```