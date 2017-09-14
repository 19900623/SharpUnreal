#pragma once

struct _MonoClass;
struct _MonoImage;
struct _MonoMethod;

/**
* ������MonoClass��UClass�Ķ�Ӧ��ϵ
*/
class NetCallbackTable
{
public:
	static bool CreateTable(_MonoImage* engine,_MonoImage* main);
	
	static void DestroyTable();
	
	static _MonoMethod* GetMethod(_MonoClass* mono_class,int id);

};
