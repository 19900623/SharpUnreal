// Fill out your copyright notice in the Description page of Project Settings.

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
