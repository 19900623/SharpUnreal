#pragma once

#include "mono/metadata/metadata.h"

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/class.h>
#include <mono/metadata/mono-config.h>
#include <mono/metadata/debug-helpers.h>

/**
* ����Mono������Ĵ�����C# dll����
*/
class SHARPUNREAL_API MonoRuntime
{
public:
	//����һ��ȫ��Mono����ʱ
	static int CreateInstance();
	//����ȫ��Mono����ʱ
	static void DestoryInstance();
	//��ȡMono����ʱ�ĵ���
	static MonoRuntime* Instance();
	//���¼������߼��ű�
	int ReloadMainAssembly();

	MonoRuntime();
private:
	void CopyToTarget(FString &target);
private:
	MonoDomain*		m_RootDomain;
	MonoDomain*		m_ChildDomain;
	MonoAssembly*	m_MainAssembly;
	MonoImage*		m_MainImage;
};
