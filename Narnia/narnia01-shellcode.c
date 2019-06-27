#include <unistd.h>

int main()
{
    char command[] = {'/','b','i','n','/','c','a','t',0};
    char target[] = {'.','/','n','a','r','n','i','a','0','0','.','m','d', 0};
    char* argv[] = { command, target };
    char* argp[] = {};
    execve(command, argv, argp);

    return 0;
}
