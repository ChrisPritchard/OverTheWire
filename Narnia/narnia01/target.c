#include <stdlib.h>
#include <unistd.h>

void main()
{
    char *params[2];
    params[0] = "/bin/sh";
    params[1] = NULL;
    execve(params[0], params, NULL);
}