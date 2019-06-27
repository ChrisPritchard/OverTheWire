#include <stdio.h>
#include <stdlib.h>

int main()
{
    char command[] = {'c','a','t',' ','/','e','t','c','/','n','a','r','n','i','a','_','p','a','s','s','/','n','a','r','n','i','a','1',0};
    execve(command);

    return 0;
}