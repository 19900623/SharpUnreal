#pragma once

struct _MonoClass;
/**
 * ������MonoClass��UClass�Ķ�Ӧ��ϵ
 */
class MonoClassTable
{
public:
	static void CreateTable();
	static void DestroyTable();
	static UClass* GetUClassFromName(const FName& name);

};
