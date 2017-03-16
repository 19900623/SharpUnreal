#pragma once

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

	TArray<FString> GetAllMonoComponent();

	MonoRuntime();
private:
	void CopyToTarget(FString &target);
private:
	struct _MonoDomain*		m_RootDomain;
	struct _MonoDomain*		m_ChildDomain;
	struct _MonoAssembly*	m_MainAssembly;
	struct _MonoImage*		m_MainImage;
	
	struct _MonoAssembly*	m_EngineAssembly;
	struct _MonoImage*		m_EngineImage;

	TArray<FString> m_ComponentNames;
};
